namespace Trendify.Api.Services.Response;

public sealed class Error
{
    public string ErrorMessage { get; }
    public string? InnerErrorMessage { get; }

    private Error(string errorMessage, string? innerErrorMessage)
    {
        ErrorMessage = errorMessage;
        InnerErrorMessage = innerErrorMessage;
    }

    public static Error New(string errorMessage) => new(errorMessage, string.Empty);
    public static Error New(Exception ex) => new(ex.Message, ex.InnerException?.Message);
    public static Error Copy(Error target) => new(target.ErrorMessage, target.InnerErrorMessage);
}