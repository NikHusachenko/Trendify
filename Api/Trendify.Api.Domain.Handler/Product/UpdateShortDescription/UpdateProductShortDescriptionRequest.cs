using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.UpdateShortDescription;

public sealed record UpdateProductShortDescriptionRequest(Guid Id, string ShortDescription) : IRequest<Result>;