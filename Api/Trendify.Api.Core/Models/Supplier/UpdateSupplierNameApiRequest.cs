namespace Trendify.Api.Core.Models.Supplier;

public sealed record UpdateSupplierNameApiRequest
{
    public string Name { get; set; } = string.Empty;
}