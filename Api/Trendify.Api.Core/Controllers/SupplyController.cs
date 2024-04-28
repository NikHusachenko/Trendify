using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Models.Supply;
using Trendify.Api.Domain.Handler.Supply.AppendMaterialToSupply;
using Trendify.Api.Domain.Handler.Supply.CompleteSupply;
using Trendify.Api.Domain.Handler.Supply.GetSupplies;
using Trendify.Api.Domain.Handler.Supply.GetSupplyById;
using Trendify.Api.Domain.Handler.Supply.NewSupply;
using Trendify.Api.Domain.Handler.Supply.RemoveMaterialFromSupply;
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
                AsError(result.ErrorMessage!) :
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
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpPut(CompleteSupplyRoute)]
    public async Task<IActionResult> Complete([FromRoute] Guid id, CancellationToken cancellationToken = default) =>
        await SendRequest(new CompleteSupplyRequest(id))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess());

    [HttpPut(PaySupplyRoute)]
    public async Task<IActionResult> Pay([FromRoute] Guid id, CancellationToken cancellationToken = default) => Ok();
}