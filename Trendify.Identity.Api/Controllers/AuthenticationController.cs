using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Services.Extensions;
using Trendify.Identity.Api.Services.AuthenticationServices;
using Trendify.Identity.Api.Services.AuthenticationServices.Models;

namespace Trendify.Identity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInCredentials credentials) =>
        await authenticationService.SignIn(credentials)
            .Map(result => result.IsError ?
                BadRequest(new
                {
                    errorMessage = result.ErrorMessage
                }) :
                Ok(result.Value) as IActionResult);

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpCredentials credentials) =>
        await authenticationService.SignUp(credentials)
            .Map(result => result.IsError ?
                BadRequest(new
                {
                    errorMessage = result.ErrorMessage
                }) :
                Ok(result.Value) as IActionResult);

    [HttpGet("sign-out")]
    public async new Task<IActionResult> SignOut() =>
        await authenticationService.SignOut(Request.Headers.Authorization)
            .Map(result => result.IsError ?
                BadRequest(new
                {
                    errorMessage = result.ErrorMessage
                }) :
                NoContent() as IActionResult);

    [HttpGet("check-access")]
    public async Task<IActionResult> CheckAccess() =>
        await authenticationService.CheckAccess(Request.Headers.Authorization)
            .Map(result => result.IsError ?
                    BadRequest(new
                    {
                        errorMessage = result.ErrorMessage
                    }) :
                    NoContent() as IActionResult);

}