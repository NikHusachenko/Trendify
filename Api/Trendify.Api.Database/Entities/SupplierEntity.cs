namespace Trendify.Api.Database.Entities;

public sealed record SupplierEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public List<SupplyEntity> Suppliers { get; set; } = new List<SupplyEntity>();
}
