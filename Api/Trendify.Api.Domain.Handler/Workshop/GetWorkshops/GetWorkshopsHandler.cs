using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;

namespace Trendify.Api.Domain.Handler.Workshop.GetWorkshops;

public sealed class GetWorkshopsHandler(
    IGenericRepository<WorkshopEntity> repository)
    : IRequestHandler<GetWorkshopsRequest, List<WorkshopEntity>>
{
    public async Task<List<WorkshopEntity>> Handle(GetWorkshopsRequest request, CancellationToken cancellationToken) =>
        await repository.GetAll().ToListAsync();
}