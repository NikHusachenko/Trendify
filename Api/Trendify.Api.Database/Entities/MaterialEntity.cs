using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record MaterialEntity : BaseEntity
{
    public string Name { get; set; }
    public int LocalCode { get; set; }
    public string ColorHex { get; set; }
    public string ColorRgb { get; set; }
    public string ColorRal { get; set; }
    public AmountUnit AmountUnit { get; set; }
    public Currency Currency { get; set; }
    public float Price { get; set; }
    public int Count { get; set; }

    public Guid? SupplyId { get; set; }
    public SupplyEntity Supply { get; set; }

    public Guid WorkshopId { get; set; }
    public WorkshopEntity Workshop { get; set; }
}