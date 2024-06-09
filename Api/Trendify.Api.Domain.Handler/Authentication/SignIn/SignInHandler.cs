using MediatR;
using Newtonsoft.Json;
using System.Text;
using Trendify.Api.Services.Response;
using Trendify.Api.Domain.Handler.Authentication.Models;

namespace Trendify.Api.Domain.Handler.Authentication.SignIn;

public sealed class SignInHandler : IRequestHandler<SignInRequest, Result<string>>
{
    private const string SignInUrl = "https://localhost:7059/api/authentication/sign-in";
    private const string DefaultJsonMediaType = "application/json";
    private const string SignInError = "Error while authorization.";

    public async Task<Result<string>> Handle(SignInRequest request, CancellationToken cancellationToken)
    {
        HttpClient httpClient = new HttpClient();
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, SignInUrl);
        requestMessage.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, DefaultJsonMediaType);

        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
        string json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            ErrorResponseModel? errorResponse = JsonConvert.DeserializeObject<ErrorResponseModel>(json);
            return errorResponse is null ?
                Result<string>.Error(SignInError) :
                Result<string>.Success(errorResponse.ErrorMessage);
        }

        return Result<string>.Success(json);
    }
}