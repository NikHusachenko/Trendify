using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Trendify.Api.Core.Attributes;

public class IdentityAnonymousAttribute : Attribute
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context) { }
}