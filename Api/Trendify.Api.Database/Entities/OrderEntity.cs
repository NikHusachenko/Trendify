namespace Trendify.Api.Database.Entities;

public sealed record OrderEntity : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public WorkshopEntity Workshop { get; set; }

    public List<MaterialEntity> Materials { get; set; }
}