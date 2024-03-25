namespace Trendify.Database.Entities;

public sealed record CartEntity : BaseEntity
{
    public List<CartProductsEntity> Products { get; set; } = new List<CartProductsEntity>();
}