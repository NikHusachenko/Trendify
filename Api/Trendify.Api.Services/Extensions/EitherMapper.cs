using Trendify.Api.Services.Response;

namespace Trendify.Api.Services.Extensions;

public static class EitherMapper
{
    public static Either<Error, T> Map<T>(this Result<T> result) =>
        result.IsError ?
        Either<Error, T>.MapLeft(result.Err) :
        Either<Error, T>.MapRight(result.Value);

    public static async Task<Either<Error, T>> Map<T>(this Task<Result<T>> asyncResult)
    {
        Result<T> result = await asyncResult;
        return result.IsError ?
            Either<Error, T>.MapLeft(result.Err) :
            Either<Error, T>.MapRight(result.Value);
    }

/*    public static Result<T> Map<T>(this Either<Error, T> result, Func<Error, Result<T>> left, Func<T, Result<T>> right) =>
        result.IsLeft ? left(result.Left) : right(result.Right);*/
}