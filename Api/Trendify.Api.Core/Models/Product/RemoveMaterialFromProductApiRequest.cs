namespace Trendify.Api.Core.Models.Product;

public sealed record RemoveMaterialFromProductApiRequest
{
    public Guid MaterialId { get; set; }
}