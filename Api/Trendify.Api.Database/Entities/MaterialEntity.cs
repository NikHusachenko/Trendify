using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record MaterialEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ColorHex { get; set; } = string.Empty;
    public string ColorRgb { get; set; } = string.Empty;
    public string ColorRal { get; set; } = string.Empty;
    public AmountUnit AmountUnit { get; set; }
    public Currency Currency { get; set; }
    public float Price { get; set; }
    public int Count { get; set; }
    public bool IsUsed { get; set; }
    
    public Guid? OrderId { get; set; }
    public OrderEntity Order { get; set; }

    public List<DeliveryMaterialEntity> Supplies = new List<DeliveryMaterialEntity>();
    public List<MaterialWorkshopsEntity> Workshops { get; set; } = new List<MaterialWorkshopsEntity>();
    public List<MaterialBlueprintsEntity> Blueprints { get; set; } = new List<MaterialBlueprintsEntity>();
}