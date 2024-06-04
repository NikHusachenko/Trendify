using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.AppendMaterialToSupply;

public sealed record AppendMaterialToSupplyRequest(Guid MaterialId, 
    int Count,
    Guid SupplyId) : IRequest<Result>;