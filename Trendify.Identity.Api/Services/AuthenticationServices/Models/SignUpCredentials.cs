namespace Trendify.Identity.Api.Services.AuthenticationServices.Models;

public sealed record SignUpCredentials
{
    public string Email { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}