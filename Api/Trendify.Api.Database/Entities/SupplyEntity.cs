namespace Trendify.Api.Database.Entities;

public sealed record SupplyEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset? DeliveredAt { get; set; }
    public string From { get; set; }
    
    public List<MaterialEntity> Materials { get; set; } = new List<MaterialEntity>();
}