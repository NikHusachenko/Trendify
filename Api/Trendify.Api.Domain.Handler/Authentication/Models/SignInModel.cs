namespace Trendify.Api.Domain.Handler.Authentication.Models;

public sealed record SignInModel
{
    public string Login { get; set; } = string.Empty;
    public string Password {  get; set; } = string.Empty;
}