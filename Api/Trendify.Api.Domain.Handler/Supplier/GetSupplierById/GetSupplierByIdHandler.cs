using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supplier.GetSupplierById;

public sealed class GetSupplierByIdHandler(
    IGenericRepository<SupplierEntity> repository)
    : IRequestHandler<GetSupplierByIdRequest, Result<SupplierEntity>>
{
    private const string NotFoundError = "Supplier not found.";

    public async Task<Result<SupplierEntity>> Handle(GetSupplierByIdRequest request, CancellationToken cancellationToken) =>
        await repository.GetAll()
            .Include(supplier => supplier.Suppliers)
            .FirstOrDefaultAsync(supplier => supplier.Id == request.Id)
        .Map(entity => entity is null ? 
            Result<SupplierEntity>.Error(NotFoundError) :
            Result<SupplierEntity>.Success(entity));
}