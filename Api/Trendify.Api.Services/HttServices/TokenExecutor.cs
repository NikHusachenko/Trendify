using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace Trendify.Api.Services.HttServices;

public static class TokenExecutor
{
    public static string? ExecuteToken(IHeaderDictionary headers)
    {
        if (!headers.TryGetValue("Authorization", out var tokenHeader))
            return null;

        var token = tokenHeader.ToString().Split(" ").Last();

        var tokenHandler = new JwtSecurityTokenHandler();
        if (tokenHandler.CanReadToken(token))
            return token;
        else
            return null;
    }
}