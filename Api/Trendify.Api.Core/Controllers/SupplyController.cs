using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Domain.Handler.Supply.GetSupplies;
using Trendify.Api.Domain.Handler.Supply.GetSupplyById;
using Trendify.Api.Domain.Handler.Supply.NewSupply;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[Route(SupplyControllerRoute)]
[ApiController]
public class SupplyController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet(NewRoute)]
    public async Task<IActionResult> Create([FromRoute] Guid supplierId) =>
        await SendRequest(new NewSupplyRequest(supplierId))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage) :
                AsSuccess(result.Value));

    [HttpGet(GetAllRoute)]
    public async Task<IActionResult> GetAll([FromRoute] Guid supplierId) =>
        await SendRequest(new GetSuppliesRequest(supplierId))
            .Map(list => list.Any() ?
                AsSuccess(list) :
                NotFound());

    [HttpGet(GetByIdRoute)]
    public async Task<IActionResult> GetById([FromRoute] Guid supplierId, [FromRoute] Guid id) =>
        await SendRequest(new GetSupplyByIdRequest(supplierId, id))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage) :
                AsSuccess(result.Value));
}