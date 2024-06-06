namespace Trendify.Api.Core.Models.Product;

public sealed record AppendMaterialToProductApiRequest
{
    public Guid MaterialId { get; set; }
    public int Count { get; set; }
}