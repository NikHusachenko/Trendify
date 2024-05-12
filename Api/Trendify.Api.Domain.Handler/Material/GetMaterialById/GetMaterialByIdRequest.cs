using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Material.GetMaterialById;

public sealed record GetMaterialByIdRequest(Guid Id) : IRequest<Result<MaterialEntity>>;