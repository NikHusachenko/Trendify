namespace Trendify.Api.Core.Models.Product;

public sealed record UpdateProductShortDescriptionApiRequest
{
    public string ShortDescription { get; set; } = string.Empty;
}