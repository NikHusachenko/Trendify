using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.UpdateName;

public sealed record UpdateProductNameRequest(Guid Id, string Name) : IRequest<Result>;