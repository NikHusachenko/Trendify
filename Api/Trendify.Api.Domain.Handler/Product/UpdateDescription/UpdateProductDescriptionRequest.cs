using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.UpdateDescription;

public sealed record UpdateProductDescriptionRequest(Guid Id, string Description) : IRequest<Result>;