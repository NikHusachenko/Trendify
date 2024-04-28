namespace Trendify.Api.Database.Entities;

public sealed record SupplyEntity : BaseEntity
{
    public DateTimeOffset? DeliveredAt { get; set; }
    public bool IsPaid { get; set; }

    public Guid SupplierId { get; set; }
    public SupplierEntity Supplier { get; set; }

    public List<DeliveryMaterialEntity> Materials { get; set; } = new List<DeliveryMaterialEntity>();
}