namespace Trendify.Api.Domain.Handler.Authentication.SignUp.Models;

internal sealed record SignUpRequestModel
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}