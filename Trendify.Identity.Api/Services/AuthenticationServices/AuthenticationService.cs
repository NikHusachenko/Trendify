using System.Security.Claims;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;
using Trendify.Identity.Api.Services.AuthenticationServices.Models;
using Trendify.Identity.Api.Services.JwtTokenServices;
using Crypt = BCrypt.Net.BCrypt;

namespace Trendify.Identity.Api.Services.AuthenticationServices;

public sealed class AuthenticationService : IAuthenticationService
{
    private const string WasRegisteredError = "Account was created.";
    private const string AuthenticationTokenNotFoundError = "Authentication token not found.";
    private const string CredentialsNotFoundError = "Credentials not found.";
    private const string ErrorWhileRegistration = "Error while registration.";

    private readonly IGenericRepository<CredentialsEntity> _repository;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthenticationService(IGenericRepository<CredentialsEntity> genericRepository, 
        IJwtTokenService jwtTokenService)
    {
        _repository = genericRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<Result<string>> SignIn(SignInCredentials credentials)
    {
        CredentialsEntity? credentialsEntity = await GetCredentials(credentials.Login, credentials.Password);
        if (credentialsEntity is null)
        {
            return Result<string>.Error(CredentialsNotFoundError);
        }

        return await _jwtTokenService.Encode(CreateClaims(credentialsEntity));
    }

    public Task<Result> SignOut(string? token) => 
        string.IsNullOrEmpty(token) ?
            Task.FromResult(Result.Error(AuthenticationTokenNotFoundError)) :
            _jwtTokenService.DisableToken(token);
    
    public async Task<Result<string>> SignUp(SignUpCredentials credentials)
    {
        CredentialsEntity? credentialsEntity = await GetCredentials(credentials.Login, credentials.Password);
        if (credentialsEntity is not null)
        {
            return Result<string>.Error(WasRegisteredError);
        }

        (string hash, string salt) = HashPassword(credentials.Password);

        CredentialsEntity entity = new CredentialsEntity()
        {
            Email = credentials.Email,
            Login = credentials.Login,
            HashedPassword = hash,
            Salt = salt,
            Scope = string.Empty,
        };

        try
        {
            await _repository.Create(entity);
        }
        catch
        {
            return Result<string>.Error(ErrorWhileRegistration);
        }

        return await SignIn(new SignInCredentials()
        {
            Login = entity.Login,
            Password = credentials.Password
        });
    }

    public Task<Result> CheckAccess(string token) => _jwtTokenService.CheckAccess(token);

    private Task<CredentialsEntity?> GetCredentials(string login, string password) =>
        _repository.GetBy(entity => entity.Login == login &&
            VerifyHashedPassword(password, entity.HashedPassword));
    
    private (string hash, string salt) HashPassword(string password)
    {
        string salt = Crypt.GenerateSalt();
        string hash = Crypt.HashPassword(password, salt);
        return (hash, salt);
    }

    private bool VerifyHashedPassword(string password, string hashedPassword) =>
        Crypt.Verify(password, hashedPassword);

    private IEnumerable<Claim> CreateClaims(CredentialsEntity credentials) =>
    [
        new Claim(JwtClaimTypes.Id, credentials.Id.ToString()),
        new Claim(JwtClaimTypes.Login, credentials.Login),
        new Claim(JwtClaimTypes.Email, credentials.Email),
    ];
}