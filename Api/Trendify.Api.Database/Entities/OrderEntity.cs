namespace Trendify.Api.Database.Entities;

public sealed record OrderEntity : BaseEntity
{
    public Guid RequesterId { get; set; }
    public WorkshopEntity Requester { get; set; }

    public Guid CloserId { get; set; }
    public WorkshopEntity Closer { get; set; }

    public List<MaterialOrdersEntity> Materials { get; set; } = new List<MaterialOrdersEntity>();
}