using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;

namespace Trendify.Api.Domain.Handler.Material.GetMaterialsByWorkshop;

public sealed class GetMaterialsByWorkshopHandler : IRequestHandler<GetMaterialsByWorkshopRequest, List<MaterialEntity>>
{
    private readonly IGenericRepository<MaterialEntity> _repository;

    public GetMaterialsByWorkshopHandler(IGenericRepository<MaterialEntity> repository)
    {
        _repository = repository;
    }

    public async Task<List<MaterialEntity>> Handle(GetMaterialsByWorkshopRequest request, CancellationToken cancellationToken)
    {
        var materials = await _repository.GetAllBy(material =>
                material.Supplies.Any(supply => supply.Supply.WorkshopId == request.WorkshopId))
            .Include(material => material.Supplies)
                .ThenInclude(supply => supply.Supply)
            .ToListAsync(cancellationToken);

        return materials;
    }
}