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

    public List<MaterialOrdersEntity> Orders { get; set; } = new List<MaterialOrdersEntity>();
    public List<DeliveryMaterialEntity> Supplies { get; set; } = new List<DeliveryMaterialEntity>();
    public List<MaterialWorkshopsEntity> Workshops { get; set; } = new List<MaterialWorkshopsEntity>();
}