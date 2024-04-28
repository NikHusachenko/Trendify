using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;

namespace Trendify.Api.Domain.Handler.Supplier.GetSuppliers;

public sealed class GetSuppliersHandler(
    IGenericRepository<SupplierEntity> repository)
    : IRequestHandler<GetSuppliersRequest, List<SupplierEntity>>
{
    public async Task<List<SupplierEntity>> Handle(GetSuppliersRequest request, CancellationToken cancellationToken) =>
        await repository.GetAll().ToListAsync();
}