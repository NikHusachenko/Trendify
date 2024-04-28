namespace Trendify.Api.Database.Entities;

public sealed record DeliveryMaterialEntity : BaseEntity
{
    public int Count { get; set; }
    public float Price { get; set; }

    public Guid SupplyId { get; set; }
    public SupplyEntity Supply { get; set; }

    public Guid MaterialId { get; set; }
    public MaterialEntity Material { get; set; }
}