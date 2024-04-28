namespace Trendify.Api.Services.Extensions;

public static class Compressor
{
    public static async Task<T> CompressAsync<T>(this Task<Task<T>> uncompressed)
    {
        var innerTask = await uncompressed;
        return await innerTask;
    }
}