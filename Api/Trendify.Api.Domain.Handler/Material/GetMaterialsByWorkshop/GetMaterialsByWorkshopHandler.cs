using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Material.GetMaterialsByWorkshop;

public sealed class GetMaterialsByWorkshopHandler(
    IGenericRepository<WorkshopEntity> workshopRepository,
    IGenericRepository<MaterialEntity> materialRepository)
    : IRequestHandler<GetMaterialsByWorkshopRequest, Result<List<MaterialEntity>>>
{
    private const string WorkshopNotFoundError = "Workshop not found.";
    private const string IncorrectWorkshopTypeError = "Selected workshop must be a Warehouse or Cutting workshop.";

    public async Task<Result<List<MaterialEntity>>> Handle(GetMaterialsByWorkshopRequest request, CancellationToken cancellationToken) =>
        await workshopRepository.GetById(request.WorkshopId)
            .Map(entity => entity is null ?
                Result<WorkshopEntity>.Error(WorkshopNotFoundError) :
                Result<WorkshopEntity>.Success(entity))
            .Map(result => result.IsError ?
                Result<WorkshopEntity>.Error(result.Err) :
                result.Value.Type != WorkshopType.Warehouse &&
                result.Value.Type != WorkshopType.Cutting ?
                Result<WorkshopEntity>.Error(IncorrectWorkshopTypeError) :
                Result<WorkshopEntity>.Success(result.Value))
            .Map(result => result.IsError ?
                Result<List<MaterialEntity>>.Error(result.Err) :
                Result<List<MaterialEntity>>.Success(result.Value.Supplies.SelectMany(s => s.Materials.Select(dm => dm.Material)).ToList()));
}