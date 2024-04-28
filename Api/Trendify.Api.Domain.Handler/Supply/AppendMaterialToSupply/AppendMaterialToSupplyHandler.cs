using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.AppendMaterialToSupply;

public sealed class AppendMaterialToSupplyHandler(
    IGenericRepository<MaterialEntity> repository)
    : IRequestHandler<AppendMaterialToSupplyRequest, Result>
{
    public async Task<Result> Handle(AppendMaterialToSupplyRequest request, CancellationToken cancellationToken)
    {
        // TODO
        throw new Exception();
    }
}