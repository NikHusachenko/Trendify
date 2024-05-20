using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Attributes;

namespace Trendify.Api.Core.Controllers;

[IdentityAuthorize]
[Route(OrderControllerRoute)]
public sealed class OrderController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(NewBaseRoute)]
    public async Task<IActionResult> Create() => Ok();
}