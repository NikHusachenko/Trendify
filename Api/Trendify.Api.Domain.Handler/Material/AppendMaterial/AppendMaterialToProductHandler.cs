using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Material.AppendMaterial;

public sealed class AppendMaterialToProductHandler(
    IGenericRepository<ProductMaterialsEntity> repository)
    : IRequestHandler<AppendMaterialToProductRequest, Result>
{

    private const string AppendError = "Error while append material to product.";
    
    public async Task<Result> Handle(AppendMaterialToProductRequest request, CancellationToken cancellationToken)
    {
        ProductMaterialsEntity? dbRecord = await repository.GetBy(
            entity => entity.ProductId == request.ProductId && entity.MaterialId == request.MaterialId);

        return dbRecord is null ?
            await DatabaseAction(() => new ProductMaterialsEntity()
            {
                MaterialCount = request.Count,
                MaterialId = request.MaterialId,
                ProductId = request.ProductId,
            },
            repository.Create) :
            await DatabaseAction(() =>
            {
                dbRecord.MaterialCount += request.Count;
                return dbRecord;
            }, repository.Update);
    }

    private async Task<Result> DatabaseAction(Func<ProductMaterialsEntity> preparation, Func<ProductMaterialsEntity, Task> action) =>
        await preparation().TryExecuteAsync(action, AppendError);
}