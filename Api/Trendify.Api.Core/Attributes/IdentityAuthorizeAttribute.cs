using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http.Headers;
using Trendify.Api.Services.HttServices;

namespace Trendify.Api.Core.Attributes;

public class IdentityAuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
{
    private const string AuthenticationAccessUrl = "https://localhost:7059/api/authentication/check-access";
    private const string AuthenticationScheme = "Bearer";

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (context.ActionDescriptor.EndpointMetadata.OfType<IdentityAnonymousAttribute>().Any())
        {
            return;
        }

        HttpRequest request = context.HttpContext.Request;
        string? token = TokenExtractor.ExtractToken(request.Headers);
        if (string.IsNullOrWhiteSpace(token))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, AuthenticationAccessUrl);
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue(AuthenticationScheme, token);

        using HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
        if (!response.IsSuccessStatusCode)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}