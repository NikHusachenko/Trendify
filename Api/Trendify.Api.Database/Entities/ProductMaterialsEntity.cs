namespace Trendify.Api.Database.Entities;

public sealed record ProductMaterialsEntity : BaseEntity
{
    public int MaterialCount { get; set; }

    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }

    public Guid MaterialId { get; set; }
    public MaterialEntity Material { get; set; }
}