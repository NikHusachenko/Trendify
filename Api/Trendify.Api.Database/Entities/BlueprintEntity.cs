using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record BlueprintEntity : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string BlueprintURL { get; set; }

    public Guid? ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public List<MaterialEntity> Materials { get; set; } = new List<MaterialEntity>();
}