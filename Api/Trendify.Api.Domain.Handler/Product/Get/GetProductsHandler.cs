using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;

namespace Trendify.Api.Domain.Handler.Product.Get;

public sealed class GetProductsHandler(
    IGenericRepository<ProductEntity> repository)
    : IRequestHandler<GetProductsRequest, List<ProductEntity>>
{
    public async Task<List<ProductEntity>> Handle(GetProductsRequest request, CancellationToken cancellationToken) =>
        string.IsNullOrWhiteSpace(request.Query) ?
        await repository.GetAll()
            .Include(entity => entity.Materials)
                .ThenInclude(material => material.Material)
            .ToListAsync() :
        await repository.GetAllBy(entity => entity.Name.Contains(request.Query) ||
            entity.Description.Contains(request.Query) ||
            entity.ShortDescription.Contains(request.Query))
        .Include(entity => entity.Materials)
            .ThenInclude(material => material.Material)
        .ToListAsync();
}