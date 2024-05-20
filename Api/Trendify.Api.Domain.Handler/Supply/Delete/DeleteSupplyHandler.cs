using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.Delete;

public sealed class DeleteSupplyHandler(
    IGenericRepository<SupplyEntity> repository)
    : IRequestHandler<DeleteSupplyRequest, Result>
{
    private const string SupplyNotFoundError = "Supply not found.";

    public async Task<Result> Handle(DeleteSupplyRequest request, CancellationToken cancellationToken) =>
        await repository.GetById(request.Id)
            .Map(entity => entity is null ?
                Result<SupplyEntity>.Error(SupplyNotFoundError) :
                Result<SupplyEntity>.Success(entity))
            .Map(result => result.IsError ?
                Task.FromResult(Result.Error(result.ErrorMessage!)) :
                result.Value.TryExecuteAsync(repository.DeleteSoft))
            .CompressAsync();
}