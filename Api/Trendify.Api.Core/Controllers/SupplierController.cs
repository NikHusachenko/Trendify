using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Models.Supplier;
using Trendify.Api.Domain.Handler.Supplier.GetSupplierById;
using Trendify.Api.Domain.Handler.Supplier.GetSuppliers;
using Trendify.Api.Domain.Handler.Supplier.NewSupplier;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[ApiController]
[Route(SupplierControllerRoute)]
public class SupplierController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(NewRoute)]
    public async Task<IActionResult> Create([FromBody] NewSupplierApiRequest request, CancellationToken cancellationToken = default) =>
        await SendRequest(
            new NewSupplierRequest(request.Address, request.Name), 
            cancellationToken)
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage) :
            AsSuccess(result.Value));

    [HttpGet(GetAllRoute)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default) =>
        await SendRequest(new GetSuppliersRequest(), cancellationToken)
            .Map(list => list.Any() ?
                AsSuccess(list) :
                AsSuccess());

    [HttpGet(GetByIdRoute)]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default) =>
        await SendRequest(new GetSupplierByIdRequest(id), cancellationToken)
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage) :
                AsSuccess(result.Value));
}