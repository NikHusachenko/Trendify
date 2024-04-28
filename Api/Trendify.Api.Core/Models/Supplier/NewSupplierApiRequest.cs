namespace Trendify.Api.Core.Models.Supplier;

public sealed record NewSupplierApiRequest
{
    public string Address { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}