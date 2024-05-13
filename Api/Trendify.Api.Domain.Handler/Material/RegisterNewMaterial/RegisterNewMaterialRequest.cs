using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Material.RegisterNewMaterial;

public sealed record RegisterNewMaterialRequest(string Name) : IRequest<Result<Guid>>;