namespace Trendify.Api.Database.Entities;

public sealed record SupplyEntity : BaseEntity
{
    public DateTimeOffset? DeliveredAt { get; set; }
    
    public Guid SupplierId { get; set; }
    public SupplierEntity Supplier { get; set; }

    public List<MaterialEntity> Materials { get; set; } = new List<MaterialEntity>();
}