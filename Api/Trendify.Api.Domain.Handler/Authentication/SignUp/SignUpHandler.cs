using MediatR;
using Newtonsoft.Json;
using System.Text;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Database.Enums;
using Trendify.Api.Domain.Handler.Authentication.Models;

namespace Trendify.Api.Domain.Handler.Authentication.SignUp;

public sealed class SignUpHandler : IRequestHandler<SignUpRequest, Result<string>>
{
    private const string SignUpUrl = "https://localhost:7059/api/authentication/sign-up";
    private const string DefaultJsonMediaType = "application/json";
    private const string SignUpError = "Internal error while registration a new user.";
    private const string CredentialsNotFoundError = "Credentials not found.";
    private const string RegistrationError = "Error while register new user.";

    private readonly HttpClient _httpClient;
    private readonly IGenericRepository<UserEntity> _userRepository;
    private readonly IGenericRepository<CredentialsEntity> _credentialsRepository;

    public SignUpHandler(IGenericRepository<UserEntity> userRepository, 
        IGenericRepository<CredentialsEntity> credentialsRepository)
    {
        _httpClient = new HttpClient();
        _userRepository = userRepository;
        _credentialsRepository = credentialsRepository;
    }

    public async Task<Result<string>> Handle(SignUpRequest request, CancellationToken cancellationToken)
    {
        Result<string> createCredentialsResult = await CreateIfNotExists(request.Login, request.Password);
        if (createCredentialsResult.IsError)
        {
            return Result<string>.Error(createCredentialsResult.Err);
        }

        Result<CredentialsEntity> getCredentialsResult = await GetCredentials(createCredentialsResult.Value);
        if (getCredentialsResult.IsError)
        {
            return Result<string>.Error(getCredentialsResult.Err);
        }

        Result<UserEntity> registerResult = await RegisterUser(request.FirstName, request.LastName, request.MiddleName, getCredentialsResult.Value.Id, request.WorkshopId);
        if (registerResult.IsError)
        {
            return Result<string>.Error(registerResult.Err);
        }

        return Result<string>.Success(createCredentialsResult.Value);
    }

    private async Task<Result<string>> CreateIfNotExists(string Login, string Password)
    {
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, SignUpUrl);
        requestMessage.Content = new StringContent(JsonConvert.SerializeObject(new SignUpRequestModel
        {
            Login = Login,
            Password = Password
        }),
        Encoding.UTF8, DefaultJsonMediaType);
        HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);
        string json = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            return Result<string>.Success(json);
        }

        try
        {
            ErrorResponseModel? responseModel = JsonConvert.DeserializeObject<ErrorResponseModel>(json);
            return responseModel is null ?
                Result<string>.Error(SignUpError) :
                Result<string>.Error(responseModel.ErrorMessage);
        }
        catch
        {
            return Result<string>.Error(SignUpError);
        }
    }

    private async Task<Result<CredentialsEntity>> GetCredentials(string token) =>
        await _credentialsRepository
            .GetBy(record => record.AuthenticationTokens.FirstOrDefault(t => t.Token == token) != null)
            .Map(entity => entity is null ?
                Result<CredentialsEntity>.Error(CredentialsNotFoundError) :
                Result<CredentialsEntity>.Success(entity));

    private async Task<Result<UserEntity>> RegisterUser(string firstName, string lastName, string middleName, Guid credentialsId, Guid workshopId)
    {
        UserEntity dbRecord = new UserEntity()
        {
            CredentialsId = credentialsId,
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName,
            Type = EmployeeType.Employee,
            WorkshopId = workshopId
        };

        try
        {
            await _userRepository.Create(dbRecord);
        }
        catch
        {
            return Result<UserEntity>.Error(RegistrationError);
        }
        return Result<UserEntity>.Success(dbRecord);
    }

}