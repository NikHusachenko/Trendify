using MediatR;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.Domain.Handler.Material.GetMaterialsByWorkshop;

public sealed record GetMaterialsByWorkshopRequest(Guid WorkshopId) : IRequest<List<MaterialEntity>>;