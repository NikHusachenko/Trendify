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
    private const string MaterialNotFoundError = "Material not found.";
    private const string MaterialWasIncludedToSupplyError = "Material was included to supply.";

    public async Task<Result> Handle(AppendMaterialToSupplyRequest request, CancellationToken cancellationToken)
    {
        Either<Error, MaterialEntity> result = await repository.GetById(request.ProductId)
            .Map(entity => entity is null ?
                Result<MaterialEntity>.Error(MaterialNotFoundError) :
                Result<MaterialEntity>.Success(entity))
            .Map();

        if (result.IsLeft)
        {
            return Result.Error(result.Left);
        }
        
        if (result.Right.SupplyId.HasValue)
        {
            return Result.Error(MaterialWasIncludedToSupplyError);
        }

        return await result.Right.TryExecuteWithPreparation(entity => entity.SupplyId = request.SupplyId,
            async entity =>
            {
                await repository.Update(entity);
                return entity;
            })
            .Map(result => result.IsLeft ?
                Result.Error(result.Left) :
                Result.Success());

    }
}