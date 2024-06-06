using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.Get;

public sealed record GetProductsRequest(string? Query) : IRequest<List<ProductEntity>>;