namespace Trendify.Api.Core.Models.Supply;

public sealed record AppendMaterialToSupplyApiRequest
{
    public Guid MaterialId { get; set; }
    public float Price { get; set; }
    public int Count { get; set; }
}