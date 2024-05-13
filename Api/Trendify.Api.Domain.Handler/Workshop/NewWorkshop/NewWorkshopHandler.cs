using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.NewWorkshop;

public sealed class NewWorkshopHandler(
    IGenericRepository<WorkshopEntity> repository)
    : IRequestHandler<NewWorkshopRequest, Result<Guid>>
{
    private const string CantCreateNewWorkshopError = "Can't create new workshop.";

    public async Task<Result<Guid>> Handle(NewWorkshopRequest request, CancellationToken cancellationToken)
    {
        WorkshopEntity entity = new WorkshopEntity()
        {
            City = request.City,
            LocalAddress = request.LocalAddress,
            Name = request.Name,
            Street = request.Street,
            Type = request.Type,
        };
        
        return await entity.TryExecute(repository.Create)
            .Map(result => result.IsError ?
                Result<Guid>.Error(CantCreateNewWorkshopError) :
                Result<Guid>.Success(entity.Id));
    }
}