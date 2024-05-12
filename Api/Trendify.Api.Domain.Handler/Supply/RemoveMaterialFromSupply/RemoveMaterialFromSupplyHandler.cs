using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.RemoveMaterialFromSupply;

public sealed class RemoveMaterialFromSupplyHandler(
    IGenericRepository<DeliveryMaterialEntity> repository)
    : IRequestHandler<RemoveMaterialFromSupplyRequest, Result>
{
    private const string MaterialInDeliveryNotFoundError = "Material in delivery not found.";

    public async Task<Result> Handle(RemoveMaterialFromSupplyRequest request, CancellationToken cancellationToken) =>
        await repository.GetBy(entity => entity.SupplyId == request.SupplyId &&
            entity.MaterialId == request.MaterialId)
            .Map(entity => entity is null ?
                Task.FromResult(Result.Error(MaterialInDeliveryNotFoundError)) :
                entity.TryExecute(repository.DeleteHard)
            ).CompressAsync();
}