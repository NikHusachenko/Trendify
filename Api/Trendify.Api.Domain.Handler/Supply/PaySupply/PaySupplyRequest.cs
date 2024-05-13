using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.PaySupply;

public sealed record PaySupplyRequest(Guid SupplyId, Guid WarehouseId) : IRequest<Result>;