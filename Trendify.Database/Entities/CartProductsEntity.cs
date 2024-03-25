namespace Trendify.Database.Entities;

public sealed record CartProductsEntity
{
    public int Count { get; set; }
    public DateTimeOffset AppendedAt { get; set; }
    public DateTimeOffset? RemovedAt { get; set; }

    public Guid CartId { get; set; }
    public CartEntity Cart { get; set; }

    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }
}