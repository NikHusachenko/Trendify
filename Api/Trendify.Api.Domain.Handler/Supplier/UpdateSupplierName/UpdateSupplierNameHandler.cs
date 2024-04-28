using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supplier.UpdateSupplierName;

public sealed class UpdateSupplierNameHandler(
    IGenericRepository<SupplierEntity> repository)
    : IRequestHandler<UpdateSupplierNameRequest, Result>
{
    private const string SupplierNotFoundError = "Supplier not found.";

    public async Task<Result> Handle(UpdateSupplierNameRequest request, CancellationToken cancellationToken) =>
        await repository.GetById(request.Id)
            .Map(entity => entity is null ?
                Result<SupplierEntity>.Error(SupplierNotFoundError) :
                Result<SupplierEntity>.Success(entity))
            .Map(result => result.IsError ?
                Task.FromResult(Result.Error(result.Err)) :
                result.Value.TryExecuteWithPreparation((entity) =>
                {
                    entity.Name = request.Name;
                },
                async entity => repository.Update(entity))
            .Map(result => result.IsLeft ?
                Result.Error(result.Left) :
                Result.Success()))
            .CompressAsync();
}