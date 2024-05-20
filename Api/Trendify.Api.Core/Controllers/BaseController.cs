using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Trendify.Api.Core.Controllers;

[ApiController]
public abstract class BaseController(IMediator mediator) : ControllerBase
{
    protected const string SupplierControllerRoute = "api/supplier";
    protected const string UpdateSupplierNameRoute = "{supplierId:guid}/update/name";
    protected const string UpdateSupplierAddressRoute = "{supplierId:guid}/update/address";
    protected const string RemoveSupplierRoute = "{supplierId:guid}/remove";
    
    protected const string SupplyControllerRoute = "api/supplier/{supplierId:guid}/supply";
    protected const string AppendMaterialFromSupplyRoute = "{id:guid}/materials/append";
    protected const string RemoveMaterialFromSupplyRoute = "{id:guid}/materials/remove";
    protected const string CompleteSupplyRoute = "{id:guid}/complete";
    protected const string PaySupplyRoute = "{id:guid}/pay";

    protected const string MaterialControllerRoute = "api/material";

    protected const string WorkshopControllerRoute = "api/workshop";
    protected const string WorkshopMaterialsRoute = "{id:guid}/materials";
    protected const string UpdateWorkshopNameRoute = "{id:guid}/update/name";
    protected const string UpdateWorkshopInfoRoute = "{id:guid}/update/info";
    protected const string RemoveWorkshopRoute = "{id:guid}/remove";

    protected const string OrderControllerRoute = "api/workshop/{workshopId:guid}/order";

    protected const string AuthenticationControllerRoute = "api/authentication";
    protected const string SignInRoute = "sign-in";
    protected const string SignUpRoute = "sign-up";

    protected const string NewBaseRoute = "new";
    protected const string DeleteBaseRoute = "{id:guid}/delete";
    protected const string RegisterBaseNew = "register-new";
    protected const string GetAllBaseRoute = "get/all";
    protected const string GetByIdBaseRoute = "get/{id:guid}";

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