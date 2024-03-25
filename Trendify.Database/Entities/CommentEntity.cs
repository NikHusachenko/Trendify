namespace Trendify.Database.Entities;

public sealed record CommentEntity : BaseEntity
{
    public string Content { get; set; } = string.Empty;

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
}