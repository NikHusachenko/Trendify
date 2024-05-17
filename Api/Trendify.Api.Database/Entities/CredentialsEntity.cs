namespace Trendify.Api.Database.Entities;

public sealed record CredentialsEntity : BaseEntity
{
    public string Email { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string Scope { get; set; } = string.Empty;

    public List<AuthenticationTokenEntity> AuthenticationTokens { get; set; } = new List<AuthenticationTokenEntity>();
}