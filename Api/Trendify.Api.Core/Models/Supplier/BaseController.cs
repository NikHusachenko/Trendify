using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Trendify.Api.Core.Models.Supplier;

public abstract class BaseController(IMediator mediator): ControllerBase
{
    protected const string SupplierControllerRoute = "api/supplier";

    protected const string NewRoute = "new";
    protected const string GetAllRoute = "get/all";
    protected const string GetByIdRoute = "get/{id:guid}";

    protected object ToErrorResponse(string errorMessage) =>
        new
        {
            errorMessage = errorMessage
        };

    protected IActionResult AsErrorResponse(object responseObject) =>
        BadRequest(responseObject);

    protected IActionResult AsErrorResponse(string errorMessage) =>
        BadRequest(ToErrorResponse(errorMessage));

    protected IActionResult AsNotFound(string errorMessage) =>
        NotFound(ToErrorResponse(errorMessage));

    protected IActionResult AsSuccess(object value) => Ok(value);

    protected IActionResult AsSuccess() => NoContent();

    protected async Task<T> SendRequest<T>(IRequest<T> request, CancellationToken cancellationToken = default) => 
        await mediator.Send(request, cancellationToken);
}