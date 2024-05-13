using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Models.Material;
using Trendify.Api.Domain.Handler.Material.GetMaterialById;
using Trendify.Api.Domain.Handler.Material.RegisterNewMaterial;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[ApiController]
[Route(MaterialControllerRoute)]
public class MaterialController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(RegisterBaseNew)]
    public async Task<IActionResult> Create([FromBody] RegisterMaterialApiRequest request, CancellationToken cancellationToken = default) =>
        await SendRequest(new RegisterNewMaterialRequest(request.Name), cancellationToken)
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpGet(GetByIdBaseRoute)]
    public async Task<IActionResult> GetById([FromRoute]Guid id) =>
        await SendRequest(new GetMaterialByIdRequest(id))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));
}