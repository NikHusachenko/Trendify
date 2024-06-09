using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Attributes;
using Trendify.Api.Core.Models.Supplier;
using Trendify.Api.Domain.Handler.Supplier.GetSupplierById;
using Trendify.Api.Domain.Handler.Supplier.GetSuppliers;
using Trendify.Api.Domain.Handler.Supplier.NewSupplier;
using Trendify.Api.Domain.Handler.Supplier.RemoveSupplier;
using Trendify.Api.Domain.Handler.Supplier.UpdateSupplierAddress;
using Trendify.Api.Domain.Handler.Supplier.UpdateSupplierName;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[IdentityAuthorize]
[Route(SupplierControllerRoute)]
public class SupplierController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(NewBaseRoute)]
    public async Task<IActionResult> Create([FromBody] NewSupplierApiRequest request) =>
        await SendRequest(new NewSupplierRequest(request.Address, request.Name))
        .Map(result => result.IsError ?
            AsError(result.ErrorMessage!) :
            AsSuccess(result.Value));

    [HttpGet(GetAllBaseRoute)]
    public async Task<IActionResult> GetAll() =>
        await SendRequest(new GetSuppliersRequest())
            .Map(list => list.Any() ?
                AsSuccess(list) :
                AsSuccess());

    [HttpGet(GetByIdBaseRoute)]
    public async Task<IActionResult> GetById([FromRoute] Guid id) =>
        await SendRequest(new GetSupplierByIdRequest(id))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpPut(UpdateSupplierNameRoute)]
    public async Task<IActionResult> UpdateName([FromRoute] Guid supplierId, [FromBody] UpdateSupplierNameApiRequest request) =>
        await SendRequest(new UpdateSupplierNameRequest(supplierId, request.Name))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess());

    [HttpPut(UpdateSupplierAddressRoute)]
    public async Task<IActionResult> UpdateAddress([FromRoute] Guid supplierId, [FromBody] UpdateSupplierAddressApiRequest request) =>
        await SendRequest(new UpdateSupplierAddressRequest(supplierId, request.Address))
            .Map(result => result.IsError ? 
                AsError(result.ErrorMessage!) :
                AsSuccess());

    [HttpDelete(RemoveSupplierRoute)]
    public async Task<IActionResult> Remove([FromRoute] Guid supplierId) =>
        await SendRequest(new RemoveSupplierRequest(supplierId))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess());
}