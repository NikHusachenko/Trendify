using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Attributes;
using Trendify.Api.Core.Models.Supply;
using Trendify.Api.Domain.Handler.Supply.AppendMaterialToSupply;
using Trendify.Api.Domain.Handler.Supply.CompleteSupply;
using Trendify.Api.Domain.Handler.Supply.Delete;
using Trendify.Api.Domain.Handler.Supply.GetSupplies;
using Trendify.Api.Domain.Handler.Supply.GetSupplyById;
using Trendify.Api.Domain.Handler.Supply.NewSupply;
using Trendify.Api.Domain.Handler.Supply.RemoveMaterialFromSupply;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[IdentityAuthorize]
[Route(SupplyControllerRoute)]
public class SupplyController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(NewBaseRoute)]
    public async Task<IActionResult> Create([FromRoute] Guid supplierId, [FromBody] NewSupplyApiRequest request)
    {
        List<(Guid, int)> materialTuples = request.Materials
            .Select(x => (x.Id, x.Count))
            .ToList();

        return await SendRequest(new NewSupplyRequest(supplierId, request.WorkshopId, materialTuples))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));
    }

    [HttpGet(GetAllBaseRoute)]
    public async Task<IActionResult> GetAll([FromRoute] Guid supplierId) =>
        await SendRequest(new GetSuppliesRequest(supplierId))
        .Map(list => list.Any() ?
            AsSuccess(list) :
            NotFound());

    [HttpGet(GetByIdBaseRoute)]
    public async Task<IActionResult> GetById([FromRoute] Guid supplierId, [FromRoute] Guid id) =>
        await SendRequest(new GetSupplyByIdRequest(supplierId, id))
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess(result.Value));

    [HttpPut(CompleteSupplyRoute)]
    public async Task<IActionResult> Complete([FromRoute] Guid id) =>
        await SendRequest(new CompleteSupplyRequest(id))
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess());

    [HttpPost(AppendMaterialFromSupplyRoute)]
    public async Task<IActionResult> AppendMaterialToDelivery([FromRoute] Guid id, [FromBody] AppendMaterialToSupplyApiRequest request) =>
        await SendRequest(new AppendMaterialToSupplyRequest(request.MaterialId, request.Count, id))
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess());

    [HttpPost(RemoveMaterialFromSupplyRoute)]
    public async Task<IActionResult> RemoveMaterialFromDelivery([FromRoute] Guid id, [FromBody] RemoveMaterialFromSupplyApiRequest request) =>
        await SendRequest(new RemoveMaterialFromSupplyRequest(id, request.Id))
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess());

    [HttpDelete(DeleteBaseRoute)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken = default) =>
        await SendRequest(new DeleteSupplyRequest(id), cancellationToken)
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess());
}