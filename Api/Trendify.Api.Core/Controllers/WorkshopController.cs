using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Models.Workshop;
using Trendify.Api.Domain.Handler.Workshop.GetWorkshopById;
using Trendify.Api.Domain.Handler.Workshop.GetWorkshops;
using Trendify.Api.Domain.Handler.Workshop.NewWorkshop;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[ApiController]
[Route(WorkshopControllerRoute)]
public sealed class WorkshopController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(NewRoute)]
    public async Task<IActionResult> Create([FromBody] NewWorkshopApiRequest request, CancellationToken cancellationToken = default) =>
        await SendRequest(
            new NewWorkshopRequest(request.Name, request.Type, request.City, request.Street, request.LocalAddress),
            cancellationToken)
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess(result.Value));

    [HttpGet(GetByIdRoute)]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default) =>
        await SendRequest(new GetWorkshopByIdRequest(id))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpGet(GetAllRoute)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default) =>
        await SendRequest(new GetWorkshopsRequest())
            .Map(list => list.Any() ?
                AsSuccess(list) :
                AsSuccess());
}