using Trendify.Database.Models;

namespace Trendify.Database.Entities;

public sealed record ProductEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public float Rate { get; set; }
    public int Count { get; set; }
    public float Price { get; set; }
    public Currency Currency { get; set; }

    public Guid? CartId { get; set; }
    public CartEntity Cart { get; set; }

    public List<ProductImageEntity> Images { get; set; } = new List<ProductImageEntity>();
    public List<CartProductsEntity> Carts { get; set; } = new List<CartProductsEntity>();
    public List<ProductCategoriesEntity> Categories { get; set; } = new List<ProductCategoriesEntity>();
}