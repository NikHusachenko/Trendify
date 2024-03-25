using Trendify.Database.Enums;

namespace Trendify.Database.Entities;

public sealed record GalleryImageEntity : BaseEntity
{
    public ImageFormat Extension { get; set; }
}