using MediatR;
using Microsoft.Extensions.Logging;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Material;

public sealed class RegisterNewMaterialHandler(
    IGenericRepository<MaterialEntity> repository,
    ILogger<RegisterNewMaterialHandler> logger)
    : IRequestHandler<RegisterNewMaterialRequest, Result<Guid>>
{
    private const string WasCreatedError = "Material was created.";

    public async Task<Result<Guid>> Handle(RegisterNewMaterialRequest request, CancellationToken cancellationToken)
    {
        if (await repository.GetBy(entity => entity.Name == request.Name)
                .Map<MaterialEntity, bool>(entity => entity is not null))
        {
            return Result<Guid>.Error(WasCreatedError);
        }

        MaterialEntity entity = new MaterialEntity()
        {
            Name = request.Name,
        };
        
        try
        {
            await repository.Create(entity);
        }
        catch (Exception ex)
        {
            logger.LogError($"Cant' register new material: {ex.Message}");
            return Result<Guid>.Error(ex);
        }
        return Result<Guid>.Success(entity.Id);
    }
}