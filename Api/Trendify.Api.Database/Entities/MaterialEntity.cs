using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record MaterialEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ColorRgb { get; set; } = string.Empty;
    public int Count { get; set; }
    public ItemCondition State { get; set; }

    public List<ProductMaterialsEntity> Products { get; set; } = new List<ProductMaterialsEntity>();
    public List<MaterialOrdersEntity> Orders { get; set; } = new List<MaterialOrdersEntity>();
    public List<DeliveryMaterialEntity> Supplies { get; set; } = new List<DeliveryMaterialEntity>();
}