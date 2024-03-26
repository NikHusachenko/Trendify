using Trendify.Database.Enums;

namespace Trendify.Database.Entities;

public sealed record ProductImageEntity : BaseEntity
{
    public ImageFormat Extension { get; set; }

    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }
}