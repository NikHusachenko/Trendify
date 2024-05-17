using System.Security.Claims;
using Trendify.Api.Services.Response;

namespace Trendify.Identity.Api.Services.JwtTokenServices;

public interface IJwtTokenService
{
    Task<Result<string>> Encode(IEnumerable<Claim> claims);
    Result<IEnumerable<Claim>> Decode(string token);
    Task<Result> CheckAccess(string token);
    Task<Result> DisableToken(string token);
}