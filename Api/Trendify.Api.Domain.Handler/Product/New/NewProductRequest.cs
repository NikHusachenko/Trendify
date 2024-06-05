using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.New;

public sealed record NewProductRequest(string Name, string Description, string ShortDescription) : IRequest<Result<ProductEntity>>;