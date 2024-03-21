namespace Trendify.Services.Response;

public sealed class ResponseService
{
    public bool IsError { get; private init; }
    public string ErrorMessage { get; private init; } = string.Empty;

    public static ResponseService Ok() => new();
    public static ResponseService Error(string errorMessage)
        => new()
        {
            ErrorMessage = errorMessage,
            IsError = true
        };
}

public class ResponseService<T>
{
    public bool IsError { get; private init; }
    public string ErrorMessage { get; private init; } = string.Empty;
    public T Value { get; private init; }

    public static ResponseService<T> Ok(T value) => new() { Value = value };
    public static ResponseService<T> Error(string errorMessage)
        => new()
        {
            ErrorMessage = errorMessage,
            IsError = true
        };
}