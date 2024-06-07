using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.ProduceProduct;

public sealed record ProduceProductRequest(Guid WorkshopId, Guid ProductId) : IRequest<Result>;