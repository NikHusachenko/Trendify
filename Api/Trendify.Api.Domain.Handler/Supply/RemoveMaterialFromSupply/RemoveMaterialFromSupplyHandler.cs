using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.RemoveMaterialFromSupply;

public sealed class RemoveMaterialFromSupplyHandler(
    IGenericRepository<MaterialEntity> repository)
    : IRequestHandler<RemoveMaterialFromSupplyRequest, Result>
{
    public async Task<Result> Handle(RemoveMaterialFromSupplyRequest request, CancellationToken cancellationToken)
    {
        // TODO
        throw new Exception();
    }
}