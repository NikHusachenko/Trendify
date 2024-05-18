using Microsoft.IdentityModel.Tokens;
using Trendify.Api.Services.Response;
using Trendify.Identity.Api.Services.AuthenticationServices.Models;

namespace Trendify.Identity.Api.Services.AuthenticationServices;

public interface IAuthenticationService
{
    Task<Result<string>> SignUp(SignUpCredentials credentials);
    Task<Result<string>> SignIn(SignInCredentials credentials);
    Task<Result> SignOut(string? token);
    Task<Result> CheckAccess(string? token);
}