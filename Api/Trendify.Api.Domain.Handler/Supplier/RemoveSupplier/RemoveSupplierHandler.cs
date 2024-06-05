using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supplier.RemoveSupplier;

public sealed class RemoveSupplierHandler(
    IGenericRepository<SupplierEntity> repository)
    : IRequestHandler<RemoveSupplierRequest, Result>
{
    private const string SupplierNotFoundError = "Supplier not found.";

    public async Task<Result> Handle(RemoveSupplierRequest request, CancellationToken cancellationToken) =>
        await repository.GetById(request.SupplierId)
            .Map(entity => entity is null ?
                Result<SupplierEntity>.Error(SupplierNotFoundError) :
                Result<SupplierEntity>.Success(entity))
            .Map(result => result.IsError ?
                Task.FromResult(Result.Error(result.Err)) :
                result.Value.TryExecute(repository.DeleteSoft))
            .CompressAsync();
}