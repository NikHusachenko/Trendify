using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Material.GetMaterialById;

public sealed class GetMaterialByIdHandler(
    IGenericRepository<MaterialEntity> repository)
    : IRequestHandler<GetMaterialByIdRequest, Result<MaterialEntity>>
{
    private const string MaterialNotFoundError = "Material not found.";

    public async Task<Result<MaterialEntity>> Handle(GetMaterialByIdRequest request, CancellationToken cancellationToken) =>
        await repository.GetById(request.Id)
            .Map(entity => entity is null ?
                Result<MaterialEntity>.Error(MaterialNotFoundError) :
                Result<MaterialEntity>.Success(entity));
}