using MediatR;
using Microsoft.Extensions.Logging;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.NewSupply;

public sealed class NewSupplyHandler(
    IGenericRepository<SupplyEntity> supplyRepository,
    IGenericRepository<DeliveryMaterialEntity> deliveryRepository,
    ILogger<NewSupplyHandler> logger)
    : IRequestHandler<NewSupplyRequest, Result<Guid>>
{
    private const string SupplyCreatingError = "Error while create new supply.";
    private const string AppendMaterialsError = "Error while append materials to supply.";

    public async Task<Result<Guid>> Handle(NewSupplyRequest request, CancellationToken cancellationToken)
    {
        SupplyEntity entity = new SupplyEntity()
        {
            SupplierId = request.SupplierId,
            WorkshopId = request.WorkshopId,
        };

        try
        {
            await supplyRepository.Create(entity);
        }
        catch
        {
            logger.LogError(SupplyCreatingError);
            return Result<Guid>.Error(SupplyCreatingError);
        }

        List<DeliveryMaterialEntity> deliveryMaterials = request.Materials.Select(x => new DeliveryMaterialEntity()
        {
            MaterialId = x.id,
            Left = x.count,
            Delivered = x.count,
            SupplyId = entity.Id,
        }).ToList();

        try
        {
            await deliveryRepository.CreateRange(deliveryMaterials);
        }
        catch
        {
            return Result<Guid>.Error(AppendMaterialsError);
        }

        return Result<Guid>.Success(entity.Id);
    }
}