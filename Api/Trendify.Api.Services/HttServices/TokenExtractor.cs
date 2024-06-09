﻿using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Services.HttServices;

public static class TokenExtractor
{
    public static string? ExtractToken(IHeaderDictionary headers)
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