namespace Trendify.Api.Database.Entities;

public sealed record ProductImageEntity : BaseEntity
{
    public string Extention { get; set; }

    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }
}