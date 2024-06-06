using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Material.RemoveMaterial;

public sealed class RemoveMaterialFromProductHandler(
    IGenericRepository<ProductMaterialsEntity> repository)
    : IRequestHandler<RemoveMaterialFromProductRequest, Result>
{
    private const string NotFoundError = "Product not contains this material.";
    private const string RemovingError = "Error while remove material from product."; 

    public async Task<Result> Handle(RemoveMaterialFromProductRequest request, CancellationToken cancellationToken)
    {
        ProductMaterialsEntity? dbRecord = await repository.GetBy(
            entity => entity.ProductId == request.ProductId && entity.MaterialId == request.MaterialId);

        if (dbRecord is null)
        {
            return Result.Error(NotFoundError);
        }

        try
        {
            await repository.DeleteHard(dbRecord);
        }
        catch
        {
            return Result.Error(RemovingError);
        }
        return Result.Success();
    }
}