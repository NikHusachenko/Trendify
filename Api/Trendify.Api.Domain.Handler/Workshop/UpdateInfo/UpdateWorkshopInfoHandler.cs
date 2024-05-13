using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.UpdateInfo;

public sealed class UpdateWorkshopInfoHandler(
    IGenericRepository<WorkshopEntity> repository)
    : IRequestHandler<UpdateWorkshopInfoRequest, Result>
{
    private const string WorkshopNotFoundError = "Workshop not found.";

    public async Task<Result> Handle(UpdateWorkshopInfoRequest request, CancellationToken cancellationToken) =>
        await repository.GetById(request.Id)
            .Map(entity => entity is null ?
                Result<WorkshopEntity>.Error(WorkshopNotFoundError) :
                Result<WorkshopEntity>.Success(entity))
            .Map(result => result.IsError ?
                Task.FromResult(Result.Error(result.ErrorMessage!)) :
                result.Value.TryExecuteWithPreparation((entity) =>
                {
                    entity.City = request.City;
                    entity.Street = request.Street;
                    entity.LocalAddress = request.LocalAddress;
                },
                repository.Update))
            .CompressAsync();
}