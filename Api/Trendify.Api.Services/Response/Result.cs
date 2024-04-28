namespace Trendify.Api.Services.Response;

public sealed class Result
{
    public Error Err { get; }
    public string? ErrorMessage => Err.ErrorMessage;
    public bool IsError => string.IsNullOrEmpty(ErrorMessage);

    private Result(string errorMessage) => Err = Response.Error.New(errorMessage);
    private Result(Error error) => Err = Response.Error.Copy(error);
    private Result(Exception ex) => Err = Response.Error.New(ex);

    public static Result Success() => new(string.Empty);
    public static Result Error(string errorMessage) => new(errorMessage);
    public static Result Error(Error error) => new(error);
    public static Result Error(Exception ex) => new(ex);
}

public sealed class Result<T>
{
    public Error Err { get; }
    public string ErrorMessage => Err.ErrorMessage;
    public bool IsError => string.IsNullOrEmpty(ErrorMessage);
    public T Value { get; }

    private Result(T value) => Value = value;
    private Result(string errorMessage) => Err = Response.Error.New(errorMessage);
    private Result(Error error) => Err = Response.Error.Copy(error);
    private Result(Exception ex) => Err = Response.Error.New(ex);

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Error(string errorMessage) => new(errorMessage);
    public static Result<T> Error(Error error) => new(error);
    public static Result<T> Error(Exception ex) => new(ex);
}