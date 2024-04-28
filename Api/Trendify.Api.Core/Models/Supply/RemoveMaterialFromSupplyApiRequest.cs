namespace Trendify.Api.Core.Models.Supply;

public sealed record RemoveMaterialFromSupplyApiRequest
{
    public Guid SupplyId { get; set; }
}