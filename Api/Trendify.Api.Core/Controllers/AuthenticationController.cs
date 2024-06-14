using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Models.Authentication;
using Trendify.Api.Domain.Handler.Authentication.CurrentUser;
using Trendify.Api.Domain.Handler.Authentication.SignIn;
using Trendify.Api.Domain.Handler.Authentication.SignUp;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[Route(AuthenticationControllerRoute)]
public sealed class AuthenticationController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(SignInRoute)]
    public async Task<IActionResult> SignIn([FromBody] SignInApiRequest request) =>
        await SendRequest(new SignInRequest(request.Login, request.Password))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpPost(SignUpRoute)]
    public async Task<IActionResult> SignUp([FromBody] SignUpApiRequest request) =>
        await SendRequest(new SignUpRequest(request.FirstName, request.LastName, request.MiddleName, request.Login, request.Password, request.WorkshopId))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpGet(CurrentUserRoute)]
    public async Task<IActionResult> GetCurrentUser() =>
        await SendRequest(new GetCurrentUserRequest())
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));
}