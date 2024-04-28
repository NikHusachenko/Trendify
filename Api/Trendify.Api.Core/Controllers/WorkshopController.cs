using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Trendify.Api.Core.Controllers;

[ApiController]
[Route(WorkshopControllerRoute)]
public sealed class WorkshopController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(NewRoute)]
    public async Task<IActionResult> Create() => Ok();
}