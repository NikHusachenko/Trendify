namespace Trendify.Identity.Api.Services.AuthenticationServices.Models;

public class SignInCredentials
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}