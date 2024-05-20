using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Attributes;
using Trendify.Api.Core.Models.Workshop;
using Trendify.Api.Domain.Handler.Material.GetMaterialsByWorkshop;
using Trendify.Api.Domain.Handler.Workshop.GetWorkshopById;
using Trendify.Api.Domain.Handler.Workshop.GetWorkshops;
using Trendify.Api.Domain.Handler.Workshop.NewWorkshop;
using Trendify.Api.Domain.Handler.Workshop.Remove;
using Trendify.Api.Domain.Handler.Workshop.UpdateInfo;
using Trendify.Api.Domain.Handler.Workshop.UpdateName;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[IdentityAuthorize]
[Route(WorkshopControllerRoute)]
public sealed class WorkshopController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(NewBaseRoute)]
    public async Task<IActionResult> Create([FromBody] NewWorkshopApiRequest request, CancellationToken cancellationToken = default) =>
        await SendRequest(
            new NewWorkshopRequest(request.Name, request.Type, request.City, request.Street, request.LocalAddress),
            cancellationToken)
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess(result.Value));

    [HttpGet(GetByIdBaseRoute)]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default) =>
        await SendRequest(new GetWorkshopByIdRequest(id), cancellationToken)
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpGet(GetAllBaseRoute)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default) =>
        await SendRequest(new GetWorkshopsRequest(), cancellationToken)
            .Map(list => list.Any() ?
                AsSuccess(list) :
                AsSuccess());

    [HttpGet(WorkshopMaterialsRoute)]
    public async Task<IActionResult> GetMaterials([FromRoute] Guid id, CancellationToken cancellationToken = default) =>
        await SendRequest(new GetMaterialsByWorkshopRequest(id))
            .Map(list => list.Any() ?
                AsSuccess(list) :
                AsSuccess());

    [HttpPut(UpdateWorkshopNameRoute)]
    public async Task<IActionResult> UpdateName([FromRoute] Guid id, [FromBody] UpdateWorkshopNameApiRequest request,
        CancellationToken cancellationToken = default) =>
        await SendRequest(
            new UpdateWorkshopNameRequest(id, request.Name),
            cancellationToken)
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess());

    [HttpPut(UpdateWorkshopInfoRoute)]
    public async Task<IActionResult> UpdateInfo([FromRoute] Guid id, [FromBody] UpdateWorkshopInfoApiRequest request,
        CancellationToken cancellationToken = default) =>
        await SendRequest(
            new UpdateWorkshopInfoRequest(id, request.City, request.Street, request.LocalAddress),
            cancellationToken)
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess());

    [HttpDelete(RemoveWorkshopRoute)]
    public async Task<IActionResult> Remove([FromRoute] Guid id, CancellationToken cancellationToken = default) =>
        await SendRequest(new RemoveWorkshopRequest(id))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess());
}