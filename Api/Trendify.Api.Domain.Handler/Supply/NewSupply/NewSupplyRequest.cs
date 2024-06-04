using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.NewSupply;

public sealed record NewSupplyRequest(Guid SupplierId, Guid WorkshopId, IEnumerable<(Guid id, int count)> Materials) : IRequest<Result<Guid>>;