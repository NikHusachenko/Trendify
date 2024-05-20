using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.Delete;

public sealed record DeleteSupplyRequest(Guid Id) : IRequest<Result>;