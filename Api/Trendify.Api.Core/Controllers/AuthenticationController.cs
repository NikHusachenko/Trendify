using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Trendify.Api.Core.Models.Authentication;
using Trendify.Api.Domain.Handler.Authentication.SignUp;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[Route(AuthenticationControllerRoute)]
public sealed class AuthenticationController : BaseController
{
    private const string SignInUrl = "https://localhost:7059/api/authentication/sign-in";
    private const string SignUpUrl = "https://localhost:7059/api/authentication/sign-up";
    private const string DefaultJsonMediaType = "application/json";

    private readonly IMediator _mediator;
    private readonly HttpClient _httpClient;

    public AuthenticationController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
        _httpClient = new HttpClient();
    }

    [HttpPost(SignInRoute)]
    public async Task<IActionResult> SignIn([FromBody] SignInApiRequest request) =>
        await SendAuthenticationRequest(SignInUrl, request);

    [HttpPost(SignUpRoute)]
    public async Task<IActionResult> SignUp([FromBody] SignUpApiRequest request) =>
        await SendRequest(new SignUpRequest(request.FirstName, request.LastName, request.MiddleName, request.Login, request.Password, request.WorkshopId))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));
        
    private async Task<ObjectResult> SendAuthenticationRequest(string url, object request)
    {
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
        requestMessage.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, DefaultJsonMediaType);
        HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);
        return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
    }
}