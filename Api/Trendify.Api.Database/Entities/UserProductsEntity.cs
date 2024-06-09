namespace Trendify.Api.Database.Entities;

public sealed record UserProductsEntity : BaseEntity
{
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }
}