namespace Trendify.Identity.Api.Services.JwtTokenServices;

public sealed record JwtOptions
{
    public string SecurityKey { get; set; } = string.Empty;
    public int Expiration { get; set; }
}