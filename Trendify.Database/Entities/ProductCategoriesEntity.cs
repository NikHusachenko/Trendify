namespace Trendify.Database.Entities;

public sealed record ProductCategoriesEntity
{
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }

    public Guid CategoryId { get; set; }
    public CategoryEntity Category { get; set; }
}