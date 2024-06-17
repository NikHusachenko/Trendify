using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.GetSelectedList;

public sealed class GetWorkshopSelectedListHandler(
    IGenericRepository<WorkshopEntity> repository)
    : IRequestHandler<GetWorkshopSelectedListRequest, WorkshopSelectedList>
{
    public async Task<WorkshopSelectedList> Handle(GetWorkshopSelectedListRequest request, CancellationToken cancellationToken)
    {
        List<WorkshopEntity> records = await repository.GetAll().ToListAsync();
        return new WorkshopSelectedList()
        {
            Items = records.Select(item => new WorkshopSelectedItem()
            {
                Id = item.Id,
                Name = item.Name,
            }).ToList()
        };
    }
}