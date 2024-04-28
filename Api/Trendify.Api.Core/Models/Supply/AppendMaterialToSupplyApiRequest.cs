namespace Trendify.Api.Core.Models.Supply;

public sealed record AppendMaterialToSupplyApiRequest
{
    public Guid MaterialId { get; set; }
}