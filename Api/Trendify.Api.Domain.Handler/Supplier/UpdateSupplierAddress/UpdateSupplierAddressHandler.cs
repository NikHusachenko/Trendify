using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supplier.UpdateSupplierAddress;

public sealed class UpdateSupplierAddressHandler(
    IGenericRepository<SupplierEntity> repository)
    : IRequestHandler<UpdateSupplierAddressRequest, Result>
{
    private const string SupplierNotFoundError = "Supplier not found.";

    public async Task<Result> Handle(UpdateSupplierAddressRequest request, CancellationToken cancellationToken) =>
        await repository.GetById(request.SupplierId)
            .Map(entity => entity is null ?
                Result<SupplierEntity>.Error(SupplierNotFoundError) :
                Result<SupplierEntity>.Success(entity))
            .Map(result => result.IsError ?
                Task.FromResult(Result.Error(result.Err)) :
                result.Value.TryExecuteWithPreparation((entity) =>
                {
                    entity.Address = request.Address;
                },
                async entity => repository.Update(entity))
            .Map(result => result.IsLeft ?
                Result.Error(result.Left) :
                Result.Success()))
            .CompressAsync();
}