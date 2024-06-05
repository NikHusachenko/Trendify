namespace Trendify.Api.Core.Models.Product;

public sealed record UpdateProductDescriptionApiRequest
{
    public string Description { get; set; } = string.Empty;
}