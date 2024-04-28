using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Models.Material;
using Trendify.Api.Domain.Handler.Material;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[ApiController]
[Route(MaterialControllerRoute)]
public class MaterialController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(RegisterNew)]
    public async Task<IActionResult> Create([FromBody] RegisterMaterialApiRequest request, CancellationToken cancellationToken = default) =>
        await SendRequest(new RegisterNewMaterialRequest(request.Name), cancellationToken)
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage) :
                AsSuccess(result.Value));
}