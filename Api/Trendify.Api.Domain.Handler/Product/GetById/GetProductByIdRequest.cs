using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.GetById;

public sealed record GetProductByIdRequest(Guid Id) : IRequest<Result<ProductEntity>>;