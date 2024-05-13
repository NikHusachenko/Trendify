namespace Trendify.Api.Core.Models.Supply;

public sealed record PaySupplyApiRequest
{
    public Guid WarehouseId { get; set; }
}