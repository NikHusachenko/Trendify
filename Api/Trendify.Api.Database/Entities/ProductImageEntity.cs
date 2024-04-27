namespace Trendify.Api.Database.Entities;

public sealed record ProductImageEntity : BaseEntity
{
    public string Extension { get; set; } = string.Empty;
    
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }
}