using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record WorkshopEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public WorkshopType Type { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string LocalAddress { get; set; } = string.Empty;

    public List<UserEntity> Users { get; set; } = new List<UserEntity>();
    public List<OrderEntity> Requested { get; set; } = new List<OrderEntity>();
    public List<OrderEntity> Closed { get; set; } = new List<OrderEntity>();
    public List<ProductWorkshopsEntity> Products { get; set; } = new List<ProductWorkshopsEntity>();
    public List<SupplyEntity> Supplies { get; set; } = new List<SupplyEntity>();
}