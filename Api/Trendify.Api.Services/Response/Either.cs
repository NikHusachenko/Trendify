namespace Trendify.Api.Services.Response;

public sealed class Either<TL, TR>
{
    public TL Left { get; }
    public TR Right { get; }

    public bool IsLeft { get; }
    public bool IsRight { get; }

    private Either(TL left)
    {
        Left = left;
        IsLeft = true;
        IsRight = false;
    }

    private Either(TR right)
    {
        Right = right;
        IsLeft = false;
        IsRight = true;
    }

    public static Either<TL, TR> MapLeft(TL left) => new(left);
    public static Either<TL, TR> MapRight(TR right) => new(right);
}