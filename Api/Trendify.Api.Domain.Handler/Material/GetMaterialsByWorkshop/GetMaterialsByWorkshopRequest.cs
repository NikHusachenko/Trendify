using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Material.GetMaterialsByWorkshop;

public sealed record GetMaterialsByWorkshopRequest(Guid WorkshopId) : IRequest<Result<List<MaterialEntity>>>;