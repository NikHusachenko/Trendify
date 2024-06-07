using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendify.Api.Core.Attributes;
using Trendify.Api.Core.Models.Product;
using Trendify.Api.Domain.Handler.Product.AppendMaterial;
using Trendify.Api.Domain.Handler.Product.Get;
using Trendify.Api.Domain.Handler.Product.GetById;
using Trendify.Api.Domain.Handler.Product.New;
using Trendify.Api.Domain.Handler.Product.RemoveMaterial;
using Trendify.Api.Domain.Handler.Product.UpdateDescription;
using Trendify.Api.Domain.Handler.Product.UpdateName;
using Trendify.Api.Domain.Handler.Product.UpdateShortDescription;
using Trendify.Api.Services.Extensions;

namespace Trendify.Api.Core.Controllers;

[IdentityAuthorize]
[Route(ProductControllerRoute)]
public class ProductController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost(RegisterBaseNew)]
    public async Task<IActionResult> Create([FromBody] NewProductApiRequest request) =>
        await SendRequest(new NewProductRequest(request.Name, request.Description, request.ShortDescription))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpGet(GetAllBaseRoute)]
    public async Task<IActionResult> GetAll([FromQuery] GetProductsFilter filter) =>
        await SendRequest(new GetProductsRequest(filter.Query))
            .Map(result => result.Any() ?
                AsSuccess(result) :
                AsSuccess());

    [HttpGet(GetByIdBaseRoute)]
    public async Task<IActionResult> GetById([FromRoute] Guid id) =>
        await SendRequest(new GetProductByIdRequest(id))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess(result.Value));

    [HttpPut(UpdateProductNameRoute)]
    public async Task<IActionResult> UpdateName([FromRoute] Guid id, [FromBody] UpdateProductNameApiRequest request) =>
        await SendRequest(new UpdateProductNameRequest(id, request.Name))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess());

    [HttpPut(UpdateProductDescriptionRoute)]
    public async Task<IActionResult> UpdateDescription([FromRoute] Guid id, [FromBody] UpdateProductDescriptionApiRequest request) =>
        await SendRequest(new UpdateProductDescriptionRequest(id, request.Description))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess());

    [HttpPut(UpdateProductShortDescriptionRoute)]
    public async Task<IActionResult> UpdateShortDescription([FromRoute] Guid id, [FromBody] UpdateProductShortDescriptionApiRequest request) =>
        await SendRequest(new UpdateProductShortDescriptionRequest(id, request.ShortDescription))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess());

    [HttpPut(AppendMaterialToProductRoute)]
    public async Task<IActionResult> AppendMaterial([FromRoute] Guid id, [FromBody] AppendMaterialToProductApiRequest request) =>
        await SendRequest(new AppendMaterialToProductRequest(id, request.MaterialId, request.Count))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess());

    [HttpPut(RemoveMaterialFromProductRoute)]
    public async Task<IActionResult> RemoveMaterial([FromRoute] Guid id, [FromBody] RemoveMaterialFromProductApiRequest request) =>
        await SendRequest(new RemoveMaterialFromProductRequest(id, request.MaterialId))
            .Map(result => result.IsError ?
                AsError(result.ErrorMessage!) :
                AsSuccess());
}