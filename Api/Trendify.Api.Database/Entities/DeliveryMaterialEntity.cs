namespace Trendify.Api.Database.Entities;

public sealed record DeliveryMaterialEntity : BaseEntity
{
    public int Delivered { get; set; }
    public int Left { get; set; }
    
    public Guid SupplyId { get; set; }
    public SupplyEntity Supply { get; set; }

    public Guid MaterialId { get; set; }
    public MaterialEntity Material { get; set; }
}