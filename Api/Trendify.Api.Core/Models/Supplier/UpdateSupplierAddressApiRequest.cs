namespace Trendify.Api.Core.Models.Supplier;

public sealed record UpdateSupplierAddressApiRequest
{
    public string Address { get; set; } = string.Empty;
}