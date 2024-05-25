namespace Trendify.Api.Database.Entities;

public sealed record MaterialOrdersEntity : BaseEntity
{
    public Guid MaterialId { get; set; }
    public MaterialEntity Material { get; set; }

    public Guid OrderId { get; set; }
    public OrderEntity Order { get; set; }
}