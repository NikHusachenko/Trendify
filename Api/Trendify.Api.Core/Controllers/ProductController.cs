using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Attributes;
using Trendify.Api.Core.Models.Product;
using Trendify.Api.Domain.Handler.Product.New;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[IdentityAuthorize]
[Route(ProductControllerRoute)]
public class ProductController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(RegisterBaseNew)]
    public async Task<IActionResult> Create([FromBody] NewProductApiRequest request) =>
        await mediator.Send(new NewProductRequest(request.Name, request.Description, request.ShortDescription))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpGet(GetAllBaseRoute)]
    public async Task<IActionResult> GetAll([FromQuery] GetProductsFilter filter) => Ok();

    [HttpGet(GetByIdBaseRoute)]
    public async Task<IActionResult> GetById([FromRoute] Guid id) => Ok();

    [HttpPut(UpdateProductNameRoute)]
    public async Task<IActionResult> UpdateName([FromRoute] Guid id, [FromBody] UpdateProductNameApiRequest request) => Ok();

    [HttpPut(UpdateProductDescriptionRoute)]
    public async Task<IActionResult> UpdateDescription([FromRoute] Guid id, [FromBody] UpdateProductDescriptionApiRequest request) => Ok();

    [HttpPut(UpdateProductShortDescriptionRoute)]
    public async Task<IActionResult> UpdateShortDescription([FromRoute] Guid id, [FromBody] UpdateProductShortDescriptionApiRequest request) => Ok();

    [HttpPut(AppendMaterialToProductRoute)]
    public async Task<IActionResult> AppendMaterial([FromRoute] Guid id, [FromBody] EditMaterialsApiRequest request) => Ok();

    [HttpPut(RemoveMaterialFromProductRoute)]
    public async Task<IActionResult> RemoveMaterial([FromRoute] Guid id, [FromBody] EditMaterialsApiRequest request) => Ok();
}