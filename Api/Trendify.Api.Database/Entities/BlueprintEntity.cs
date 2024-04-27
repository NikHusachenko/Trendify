using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record BlueprintEntity : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string BlueprintURL { get; set; } = string.Empty;

    public List<MaterialBlueprintsEntity> Materials { get; set; } = new List<MaterialBlueprintsEntity>();
}