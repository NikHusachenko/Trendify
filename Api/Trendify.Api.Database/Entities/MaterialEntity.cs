using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record MaterialEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int LocalCode { get; set; }
    public string ColorHex { get; set; } = string.Empty;
    public string ColorRgb { get; set; } = string.Empty;
    public string ColorRal { get; set; } = string.Empty;
    public AmountUnit AmountUnit { get; set; }
    public Currency Currency { get; set; }
    public float Price { get; set; }
    public int Count { get; set; }
    
    public Guid SupplyId { get; set; }
    public SupplyEntity Supply { get; set; }
    
    public Guid? OrderId { get; set; }
    public OrderEntity Order { get; set; }

    public Guid WorkshopId { get; set; }
    public WorkshopEntity Workshop { get; set; }

    public List<MaterialBlueprintsEntity> Blueprints { get; set; } = new List<MaterialBlueprintsEntity>();
}