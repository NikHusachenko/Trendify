namespace Trendify.Api.Database.Entities;

public sealed record MaterialBlueprintsEntity : BaseEntity
{
    public Guid MaterialId { get; set; }
    public MaterialEntity Material { get; set; }

    public Guid BlueprintId { get; set; }
    public BlueprintEntity Blueprint { get; set; }
}