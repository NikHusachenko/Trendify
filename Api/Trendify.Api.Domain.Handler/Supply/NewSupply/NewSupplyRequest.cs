using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.NewSupply;

public sealed record NewSupplyRequest(Guid SupplierId) : IRequest<Result<Guid>>;