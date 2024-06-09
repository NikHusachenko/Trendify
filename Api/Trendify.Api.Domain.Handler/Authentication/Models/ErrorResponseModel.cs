namespace Trendify.Api.Domain.Handler.Authentication.Models;

internal sealed record ErrorResponseModel
{
    public string ErrorMessage { get; set; } = string.Empty;
}