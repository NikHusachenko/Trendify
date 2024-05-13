using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.Remove;

public sealed class RemoveWorkshopHandler(
    IGenericRepository<WorkshopEntity> repository)
    : IRequestHandler<RemoveWorkshopRequest, Result>
{
    public async Task<Result> Handle(RemoveWorkshopRequest request, CancellationToken cancellationToken) =>
         await repository.GetById(request.Id)
            .Map(entity => entity is null ?
                Result<WorkshopEntity>.Error("") :
                Result<WorkshopEntity>.Success(entity))
            .Map(result => result.IsError ?
                Task.FromResult(Result.Error(result.ErrorMessage!)) :
                result.Value.TryExecuteAsync(repository.DeleteSoft))
        .CompressAsync();
}