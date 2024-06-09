namespace Trendify.Api.Domain.Handler.Authentication.SignUp.Models;

internal sealed record ErrorResponseModel
{
    public string ErrorMessage { get; set; } = string.Empty;
}