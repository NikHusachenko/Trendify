using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.PaySupply;

public sealed class PaySupplyHandler(
    IGenericRepository<SupplyEntity> repository)
    : IRequestHandler<PaySupplyRequest, Result>
{
    public Task<Result> Handle(PaySupplyRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}