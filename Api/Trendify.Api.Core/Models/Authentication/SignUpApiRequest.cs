﻿namespace Trendify.Api.Core.Models.Authentication;

public sealed record SignUpApiRequest
{
    public string Email { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}