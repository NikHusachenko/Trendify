using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record BlueprintEntity : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string BlueprintURL { get; set; }

    public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    public List<MaterialEntity> Materials { get; set; } = new List<MaterialEntity>();
}