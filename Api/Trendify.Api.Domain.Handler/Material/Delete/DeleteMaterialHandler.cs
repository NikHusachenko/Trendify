using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Material.Delete;

public sealed class DeleteMaterialHandler(
    IGenericRepository<MaterialEntity> repository)
    : IRequestHandler<DeleteMaterialRequest, Result>
{
    private const string MaterialNotFoundError = "Material not found.";

    public async Task<Result> Handle(DeleteMaterialRequest request, CancellationToken cancellationToken) =>
        await repository.GetById(request.Id)
            .Map(entity => entity is null ?
                Result<MaterialEntity>.Error(MaterialNotFoundError) :
                Result<MaterialEntity>.Success(entity))
            .Map(result => result.IsError ?
                Task.FromResult(Result.Error(result.ErrorMessage!)) :
                result.Value.TryExecuteAsync(repository.DeleteSoft))
            .CompressAsync();
}