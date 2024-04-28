using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.CompleteSupply;

public sealed record CompleteSupplyRequest(Guid Id) : IRequest<Result>;