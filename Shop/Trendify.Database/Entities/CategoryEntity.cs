namespace Trendify.Database.Entities;

public sealed record CategoryEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public List<ProductCategoriesEntity> Products { get; set; } = new List<ProductCategoriesEntity>();
}