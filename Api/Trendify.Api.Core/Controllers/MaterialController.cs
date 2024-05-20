using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Attributes;
using Trendify.Api.Core.Models.Material;
using Trendify.Api.Domain.Handler.Material.GetMaterialById;
using Trendify.Api.Domain.Handler.Material.GetMaterials;
using Trendify.Api.Domain.Handler.Material.RegisterNewMaterial;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[IdentityAuthorize]
[Route(MaterialControllerRoute)]
public class MaterialController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(RegisterBaseNew)]
    public async Task<IActionResult> Create([FromBody] RegisterMaterialApiRequest request,
        CancellationToken cancellationToken = default) =>
        await SendRequest(new RegisterNewMaterialRequest(request.Name), cancellationToken)
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpGet(GetByIdBaseRoute)]
    public async Task<IActionResult> GetById([FromRoute]Guid id, CancellationToken cancellationToken = default) =>
        await SendRequest(new GetMaterialByIdRequest(id), cancellationToken)
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpGet(GetAllBaseRoute)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default) =>
        await SendRequest(new GetMaterialsRequest(), cancellationToken)
            .Map(list => list.Any() ?
                AsSuccess(list) :
                AsSuccess());
}