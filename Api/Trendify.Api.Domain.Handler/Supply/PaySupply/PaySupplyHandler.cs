using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.PaySupply;

public sealed class PaySupplyHandler(
    IGenericRepository<SupplyEntity> supplyRepository,
    IGenericRepository<WorkshopEntity> workshopRepository)
    : IRequestHandler<PaySupplyRequest, Result>
{
    private const string WarehouseNotFoundError = "Warehouse not found.";
    private const string WorkshopIsNotWarehouseError = "Selected workshop is not a warehouse";
    private const string SupplyNotFoundError = "Supply not found.";

    public async Task<Result> Handle(PaySupplyRequest request, CancellationToken cancellationToken)
    {
        Result<WorkshopEntity> warehouseResult = await workshopRepository
            .GetBy(entity => entity.Id == request.WarehouseId)
            .Map(entity => entity is null ?
                Result<WorkshopEntity>.Error(WarehouseNotFoundError) :
                Result<WorkshopEntity>.Success(entity))
            .Map(async asyncResult =>
            {
                Result<WorkshopEntity> result = await asyncResult;

                if (result.IsError is false &&
                    result.Value.Type is not WorkshopType.Warehouse)
                {
                    return Result<WorkshopEntity>.Error(WorkshopIsNotWarehouseError);
                }

                return result;
            });

        return warehouseResult.IsError ?
            Result.Error(warehouseResult.ErrorMessage!) :
            await warehouseResult.Value.TryExecuteAsync(async entity =>
                await supplyRepository.GetById(request.SupplyId)
                        .Map(entity => entity is null ?
                            Task.FromResult(Result.Error(SupplyNotFoundError)) :
                            entity.TryExecuteWithPreparation(
                                entity =>
                                {
                                    entity.IsPaid = true;
                                },
                                supplyRepository.Update)
                            ));
    }
}