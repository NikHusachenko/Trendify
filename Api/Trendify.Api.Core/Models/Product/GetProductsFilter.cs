namespace Trendify.Api.Core.Models.Product;

public sealed record GetProductsFilter
{
    public string? Query { get; set; }
}