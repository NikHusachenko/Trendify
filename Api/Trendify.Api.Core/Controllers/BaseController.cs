using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Trendify.Api.Core.Controllers;

public abstract class BaseController(IMediator mediator) : ControllerBase
{
    protected const string SupplierControllerRoute = "api/supplier";
    protected const string UpdateSupplierNameRoute = "{supplierId:guid}/update/name";
    protected const string UpdateSupplierAddressRoute = "{supplierId:guid}/update/address";
    protected const string RemoveSupplierRoute = "{supplierId:guid}/remove";
    
    protected const string SupplyControllerRoute = "api/supplier/{supplierId:guid}/supply";
    protected const string AppendMaterialFromSupplyRoute = "{id:guid}/materials/append";
    protected const string RemoveMaterialFromSupplyRoute = "{id:guid}/materials/remove";
    protected const string CompleteSupplyRoute = "complete/{id:guid}";
    protected const string PaySupplyRoute = "pay/{id:guid}";

    protected const string MaterialControllerRoute = "api/material";
    // protected const string AttachNewMaterialIntoSupplyRoute = "api/material/supply/{supplyId:guid}/attach";

    protected const string WorkshopControllerRoute = "api/workshop";

    protected const string OrderControllerRoute = "api/workshop/{workshopId:guid}/order";

    protected const string NewRoute = "new";
    protected const string RegisterNew = "register-new";
    protected const string GetAllRoute = "get/all";
    protected const string GetByIdRoute = "get/{id:guid}";

    protected async Task<T> SendRequest<T>(IRequest<T> request, CancellationToken cancellationToken = default) =>
        await mediator.Send(request, cancellationToken);

    protected object ToErrorResponse(string errorMessage) =>
        new
        {
            errorMessage
        };
    
    protected IActionResult AsError(object responseObject) =>
        BadRequest(responseObject);

    protected IActionResult AsError(string errorMessage) =>
        BadRequest(ToErrorResponse(errorMessage));

    protected IActionResult AsNotFound(string errorMessage) =>
        NotFound(ToErrorResponse(errorMessage));

    protected IActionResult AsSuccess(object value) => Ok(value);

    protected IActionResult AsSuccess() => NoContent();
}