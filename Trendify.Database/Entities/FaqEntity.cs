namespace Trendify.Database.Entities;

public sealed record FaqEntity : BaseEntity
{
    public string FaqName { get; set; } = string.Empty;
    public string FaqDescription { get; set; } = string.Empty;
}