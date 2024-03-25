namespace Trendify.Database.Entities;

public sealed record ProductImageEntity : BaseEntity
{
    public string Extension { get; set; } = string.Empty;
}