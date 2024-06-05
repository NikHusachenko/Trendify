namespace Trendify.Api.Core.Models.Product;

public sealed record UpdateProductNameApiRequest
{
    public string Name { get; set; } = string.Empty;
}