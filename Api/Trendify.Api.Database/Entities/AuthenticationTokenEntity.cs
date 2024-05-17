namespace Trendify.Api.Database.Entities;

public sealed record AuthenticationTokenEntity : BaseEntity
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
    public bool IsActive { get; set; }

    public Guid CredentialsId { get; set; }
    public CredentialsEntity Credentials { get; set; }
}