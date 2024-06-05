namespace Trendify.Api.Core.Models.Product;

public sealed record EditMaterialsApiRequest
{
    public Guid MaterialId { get; set; }
}