using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Models.Supply;
using Trendify.Api.Domain.Handler.Supply.AppendMaterialToSupply;
using Trendify.Api.Domain.Handler.Supply.CompleteSupply;
using Trendify.Api.Domain.Handler.Supply.GetSupplies;
using Trendify.Api.Domain.Handler.Supply.GetSupplyById;
using Trendify.Api.Domain.Handler.Supply.NewSupply;
using Trendify.Api.Domain.Handler.Supply.PaySupply;
using Trendify.Api.Domain.Handler.Supply.RemoveMaterialFromSupply;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[ApiController]
[Route(SupplyControllerRoute)]
public class SupplyController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(NewRoute)]
    public async Task<IActionResult> Create([FromRoute] Guid supplierId, CancellationToken cancellationToken = default) =>
        await SendRequest(new NewSupplyRequest(supplierId), 
            cancellationToken)
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess(result.Value));

    [HttpGet(GetAllRoute)]
    public async Task<IActionResult> GetAll([FromRoute] Guid supplierId, CancellationToken cancellationToken = default) =>
        await SendRequest(new GetSuppliesRequest(supplierId), 
            cancellationToken)
        .Map(list => list.Any() ?
            AsSuccess(list) :
            NotFound());

    [HttpGet(GetByIdRoute)]
    public async Task<IActionResult> GetById([FromRoute] Guid supplierId, [FromRoute] Guid id, CancellationToken cancellationToken = default) =>
        await SendRequest(new GetSupplyByIdRequest(supplierId, id), 
            cancellationToken)
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess(result.Value));

    [HttpPut(CompleteSupplyRoute)]
    public async Task<IActionResult> Complete([FromRoute] Guid id, CancellationToken cancellationToken = default) =>
        await SendRequest(new CompleteSupplyRequest(id),
            cancellationToken)
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess());

    [HttpPost(AppendMaterialFromSupplyRoute)]
    public async Task<IActionResult> AppendMaterialToDelivery([FromRoute] Guid id, [FromBody] AppendMaterialToSupplyApiRequest request,
        CancellationToken cancellationToken = default) =>
        await SendRequest(
            new AppendMaterialToSupplyRequest(request.MaterialId, request.Count, request.Price, id),
            cancellationToken)
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess());

    [HttpPost(RemoveMaterialFromSupplyRoute)]
    public async Task<IActionResult> RemoveMaterialFromDelivery([FromRoute] Guid id, [FromBody] RemoveMaterialFromSupplyApiRequest request,
        CancellationToken cancellationToken = default) =>
        await SendRequest(new RemoveMaterialFromSupplyRequest(id, request.Id),
            cancellationToken)
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess());

    [HttpPut(PaySupplyRoute)]
    public async Task<IActionResult> Pay([FromRoute] Guid id, [FromBody] PaySupplyApiRequest request,
        CancellationToken cancellationToken = default) =>
        await SendRequest(new PaySupplyRequest(id, request.WarehouseId),
            cancellationToken)
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess());
}