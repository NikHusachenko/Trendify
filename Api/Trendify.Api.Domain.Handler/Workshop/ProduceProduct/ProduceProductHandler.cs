using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.Domain.Handler.Workshop.ProduceProduct;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.ProduceProduct;

public sealed class CanProduceProductHandler(
    IGenericRepository<ProductEntity> productRepository,
    IGenericRepository<SupplyEntity> supplyRepository,
    IGenericRepository<ProductWorkshopsEntity> productWorkshopRepository,
    IGenericRepository<DeliveryMaterialEntity> deliveryRepository)
    : IRequestHandler<ProduceProductRequest, Result>
{
    private const string ProductNotFoundError = "Product not found.";
    private const string WorkshopNotFoundError = "Workshop not found.";
    private const string MaterialNotAvailableError = "Material Not Available.";
    private const string ProducingError = "Error while producing product.";

    private async Task<ProductEntity?> GetProductWithMaterialsAsync(Guid productId)
    {
        return await productRepository.GetAll()
            .Include(product => product.Materials)
                .ThenInclude(pm => pm.Material)
            .FirstOrDefaultAsync(product => product.Id == productId);
    }

    private async Task<Dictionary<Guid, int>> GetMaterialQuantitiesAsync(Guid workshopId, IEnumerable<Guid> materialIds)
    {
        var supplies = await supplyRepository.GetAll()
            .Where(s => s.WorkshopId == workshopId &&
                s.DeliveredAt.HasValue)
            .Include(s => s.Materials)
            .ToListAsync();

        return supplies
            .SelectMany(s => s.Materials)
            .Where(dm => materialIds.Contains(dm.MaterialId))
            .GroupBy(dm => dm.MaterialId)
            .ToDictionary(g => g.Key, g => g.Sum(dm => dm.Left));
    }

    private bool HasSufficientMaterials(Dictionary<Guid, int> requiredMaterials, Dictionary<Guid, int> materialQuantities)
    {
        foreach (var requiredMaterial in requiredMaterials)
        {
            if (!materialQuantities.TryGetValue(requiredMaterial.Key, out var availableCount) || availableCount < requiredMaterial.Value)
            {
                return false;
            }
        }
        return true;
    }

    private async Task<Result> UpdateMaterialCountsAsync(Guid workshopId, Dictionary<Guid, int> requiredMaterials)
    {
        var supplies = await supplyRepository.GetAll()
            .Where(s => s.WorkshopId == workshopId)
            .Include(s => s.Materials)
            .ToListAsync();

        var remainingRequiredMaterials = new Dictionary<Guid, int>(requiredMaterials);

        foreach (var supply in supplies)
        {
            foreach (var deliveryMaterial in supply.Materials)
            {
                if (remainingRequiredMaterials.TryGetValue(deliveryMaterial.MaterialId, out var requiredCount))
                {
                    var usedCount = Math.Min(deliveryMaterial.Left, requiredCount);
                    deliveryMaterial.Left -= usedCount;
                    requiredCount -= usedCount;
                    remainingRequiredMaterials[deliveryMaterial.MaterialId] = requiredCount;

                    try
                    {
                        await deliveryRepository.Update(deliveryMaterial);
                    }
                    catch
                    {
                        return Result.Error(ProducingError);
                    }

                    if (requiredCount == 0)
                    {
                        break;
                    }
                }
            }

            if (remainingRequiredMaterials.Values.All(count => count == 0))
            {
                break;
            }
        }

        if (remainingRequiredMaterials.Values.Any(count => count > 0))
            return Result.Error(MaterialNotAvailableError);

        return Result.Success();
    }

    private async Task<Result> UpdateProductWorkshopCountAsync(Guid workshopId, Guid productId)
    {
        var productWorkshop = await productWorkshopRepository.GetAll()
            .FirstOrDefaultAsync(pw => pw.ProductId == productId && pw.WorkshopId == workshopId);

        if (productWorkshop != null)
        {
            productWorkshop.Count += 1;

            try
            {
                await productWorkshopRepository.Update(productWorkshop);
            }
            catch
            {
                return Result.Error(ProductNotFoundError);
            }
        }
        else
        {
            productWorkshop = new ProductWorkshopsEntity
            {
                ProductId = productId,
                WorkshopId = workshopId,
                Count = 1
            };

            try
            {
                await productWorkshopRepository.Create(productWorkshop);
            }
            catch
            {
                return Result.Error(ProducingError);
            }
        }

        return Result.Success();
    }

    public async Task<Result> Handle(ProduceProductRequest request, CancellationToken cancellationToken)
    {
        var productRecord = await GetProductWithMaterialsAsync(request.ProductId);
        if (productRecord is null)
        {
            return Result.Error(ProductNotFoundError);
        }
        var requiredMaterials = productRecord.Materials.ToDictionary(pm => pm.MaterialId, pm => pm.MaterialCount);
        var materialQuantities = await GetMaterialQuantitiesAsync(request.WorkshopId, requiredMaterials.Keys);

        if (!HasSufficientMaterials(requiredMaterials, materialQuantities))
        {
            return Result.Error(MaterialNotAvailableError);
        }

        Result updateMaterialResult = await UpdateMaterialCountsAsync(request.WorkshopId, requiredMaterials);
        if (updateMaterialResult.IsError)
        {
            return updateMaterialResult;
        }

        return await UpdateProductWorkshopCountAsync(request.WorkshopId, request.ProductId);
    }
}