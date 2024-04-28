using Trendify.Api.Services.Response;

namespace Trendify.Api.Services.Extensions;

public static class Try
{
    public static async Task<Either<Error, TR>> TryExecute<TIn, TR>(this TIn arg, Func<TIn, Task<TR>> func)
    {
        try
        {
            TR result = await func(arg);
            return Either<Error, TR>.MapRight(result);
        }
        catch (Exception ex)
        {
            return Either<Error, TR>.MapLeft(Error.New(ex));
        }
    }

    public static Either<Error, TR> TryExecute<TIn, TR>(this TIn arg, Func<TIn, TR> func)
    {
        try
        {
            TR result = func(arg);
            return Either<Error, TR>.MapRight(result);
        }
        catch (Exception ex)
        {
            return Either<Error, TR>.MapLeft(Error.New(ex));
        }
    }

    public static async Task<Result> TryExecute<TIn>(this TIn arg, Func<TIn, Task> func)
    {
        try
        {
            await func(arg);
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
        return Result.Success();
    }

    public static Result TryExecute<TIn>(this TIn arg, Action<TIn> action)
    {
        try
        {
            action(arg);
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
        return Result.Success();
    }
}