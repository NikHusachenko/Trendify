using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;

namespace Trendify.Api.Domain.Handler.Material.GetMaterials;

public sealed class GetMaterialsHandler(
    IGenericRepository<MaterialEntity> repository)
    : IRequestHandler<GetMaterialsRequest, List<MaterialEntity>>
{
    public async Task<List<MaterialEntity>> Handle(GetMaterialsRequest request, CancellationToken cancellationToken) =>
        await repository.GetAll().ToListAsync();
}