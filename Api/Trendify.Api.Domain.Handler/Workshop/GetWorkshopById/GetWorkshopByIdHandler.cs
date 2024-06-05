using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.GetWorkshopById;

public sealed class GetWorkshopByIdHandler(
    IGenericRepository<WorkshopEntity> repository)
    : IRequestHandler<GetWorkshopByIdRequest, Result<WorkshopEntity>>
{
    private const string WorkshopNotFoundError = "Workshop not found.";

    public async Task<Result<WorkshopEntity>> Handle(GetWorkshopByIdRequest request, CancellationToken cancellationToken) =>
        await repository.GetById(request.Id)
            .Map(entity => entity is null ?
                Result<WorkshopEntity>.Error(WorkshopNotFoundError) :
                Result<WorkshopEntity>.Success(entity));
}