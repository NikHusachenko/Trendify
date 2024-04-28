using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;

namespace Trendify.Api.Domain.Handler.Supply.GetSupplies;

public sealed class GetSuppliesHandler(
    IGenericRepository<SupplyEntity> repository)
    : IRequestHandler<GetSuppliesRequest, List<SupplyEntity>>
{
    public async Task<List<SupplyEntity>> Handle(GetSuppliesRequest request, CancellationToken cancellationToken) =>
        await repository.GetAllBy(supply => supply.SupplierId == request.supplierId).ToListAsync();
}