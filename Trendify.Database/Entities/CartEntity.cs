namespace Trendify.Database.Entities;

public sealed record CartEntity : BaseEntity
{
    public bool isClosed { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }

    public List<CartProductsEntity> Products { get; set; } = new List<CartProductsEntity>();
}