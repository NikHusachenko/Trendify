using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Trendify.Api.Core.Controllers;

[ApiController]
[Route(OrderControllerRoute)]
public sealed class OrderController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(NewRoute)]
    public async Task<IActionResult> Create() => Ok();
}