using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.AppendMaterialToSupply;

public sealed class AppendMaterialToSupplyHandler(
    IGenericRepository<DeliveryMaterialEntity> repository)
    : IRequestHandler<AppendMaterialToSupplyRequest, Result>
{
    public async Task<Result> Handle(AppendMaterialToSupplyRequest request, CancellationToken cancellationToken) =>
        await new DeliveryMaterialEntity()
        {
            Left = request.Count,
            MaterialId = request.MaterialId,
            SupplyId = request.SupplyId,
        }.TryExecute(repository.Create);
}