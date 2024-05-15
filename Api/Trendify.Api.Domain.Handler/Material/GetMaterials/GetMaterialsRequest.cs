using MediatR;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.Domain.Handler.Material.GetMaterials;

public sealed record GetMaterialsRequest : IRequest<List<MaterialEntity>>;