using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record ProductEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public Currency Currency { get; set; }
    public float Price { get; set; }
    public int Count { get; set; }
    public float Rate { get; set; }
    public int Bought { get; set; }

    public Guid WorkshopId { get; set; }
    public WorkshopEntity Workshop { get; set; }

    public List<ProductImageEntity> Images { get; set; } = new List<ProductImageEntity>();
}