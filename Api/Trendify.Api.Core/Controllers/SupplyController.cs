using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Domain.Handler.Supply.GetSupplies;
using Trendify.Api.Domain.Handler.Supply.GetSupplyById;
using Trendify.Api.Domain.Handler.Supply.NewSupply;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[ApiController]
[Route(SupplyControllerRoute)]
public class SupplyController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(NewRoute)]
    public async Task<IActionResult> Create([FromRoute] Guid supplierId, CancellationToken cancellationToken = default) =>
        await SendRequest(new NewSupplyRequest(supplierId), cancellationToken)
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage) :
                AsSuccess(result.Value));

    [HttpGet(GetAllRoute)]
    public async Task<IActionResult> GetAll([FromRoute] Guid supplierId, CancellationToken cancellationToken = default) =>
        await SendRequest(new GetSuppliesRequest(supplierId), cancellationToken)
            .Map(list => list.Any() ?
                AsSuccess(list) :
                NotFound());

    [HttpGet(GetByIdRoute)]
    public async Task<IActionResult> GetById([FromRoute] Guid supplierId, [FromRoute] Guid id, CancellationToken cancellationToken = default) =>
        await SendRequest(new GetSupplyByIdRequest(supplierId, id), cancellationToken)
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage) :
                AsSuccess(result.Value));
}