using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.CompleteSupply;

public sealed class CompleteSupplyHandler(
    IGenericRepository<SupplyEntity> repository)
    : IRequestHandler<CompleteSupplyRequest, Result>
{
    private const string SupplyNotFountError = "Supply not found.";

    public async Task<Result> Handle(CompleteSupplyRequest request, CancellationToken cancellationToken) =>
        await repository.GetBy(entity => entity.Id == request.Id, cancellationToken)
            .Map(entity => entity is null ?
                Result<SupplyEntity>.Error(SupplyNotFountError) :
                Result<SupplyEntity>.Success(entity))
            .Map(result => result.IsError ?
                Task.FromResult(Result.Error(result.Err)) :
                result.Value.TryExecuteWithPreparation(entity =>
                {
                    entity.DeliveredAt = DateTime.Now.ToUniversalTime();
                },
                async entity => repository.Update(entity))
            .Map(result => result.IsLeft ?
                Result.Error(result.Left) :
                Result.Success()))
            .CompressAsync();
}