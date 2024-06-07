using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.AppendMaterial;

public sealed record AppendMaterialToProductRequest(Guid ProductId, Guid MaterialId, int Count) : IRequest<Result>;