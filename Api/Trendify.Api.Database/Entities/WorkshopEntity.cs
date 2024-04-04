using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record WorkshopEntity : BaseEntity
{
    public string Name { get; set; }
    public WorkshopType Type { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int BuildingNumber { get; set; }
    public int? CorpsNumber { get; set; }
    public string? AdditionAddress { get; set; }

    public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    public List<UserEntity> Users { get; set; } = new List<UserEntity>();
    public List<MaterialEntity> Materials { get; set; } = new List<MaterialEntity>();
}