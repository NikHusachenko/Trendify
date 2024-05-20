using Microsoft.AspNetCore.Mvc.Filters;

namespace Trendify.Api.Core.Attributes;

public class IdentityAnonymousAttribute : Attribute, IAsyncAuthorizationFilter
{
    private const string AuthenticationAccessUrl = "https://localhost:7059/api/authentication/check-access";
    private const string AuthenticationScheme = "Bearer";

    public Task OnAuthorizationAsync(AuthorizationFilterContext context) => Task.CompletedTask;
}