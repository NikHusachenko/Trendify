using Trendify.Api.Database.Enums;

namespace Trendify.Api.Database.Entities;

public sealed record ProductEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public float Price { get; set; }

    public List<ProductMaterialsEntity> Materials { get; set; } = new List<ProductMaterialsEntity>();
    public List<ProductImageEntity> Images { get; set; } = new List<ProductImageEntity>();
    public List<ProductWorkshopsEntity> Workshops { get; set; } = new List<ProductWorkshopsEntity>();
}