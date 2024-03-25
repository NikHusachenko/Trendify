using Trendify.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

public sealed record ActionEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
}