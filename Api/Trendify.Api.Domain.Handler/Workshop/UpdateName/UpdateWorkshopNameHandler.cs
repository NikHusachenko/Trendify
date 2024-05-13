using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.UpdateName;

public sealed class UpdateWorkshopNameHandler (
    IGenericRepository<WorkshopEntity> repository)
    : IRequestHandler<UpdateWorkshopNameRequest, Result>
{
    private const string WorkshopNotFoundError = "Workshop not found.";

    public async Task<Result> Handle(UpdateWorkshopNameRequest request, CancellationToken cancellationToken) =>
        await repository.GetById(request.Id)
            .Map(entity => entity is null ?
                Result<WorkshopEntity>.Error(WorkshopNotFoundError) :
                Result<WorkshopEntity>.Success(entity))
            .Map(result => result.IsError ?
                Task.FromResult(Result.Error(result.Err)) :
                result.Value.TryExecuteWithPreparation((entity) =>
                {
                    entity.Name = request.Name;
                },
                repository.Update))
            .CompressAsync();
}