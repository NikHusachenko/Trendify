using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Material;

public sealed record RegisterNewMaterialRequest(string Name) : IRequest<Result<Guid>>;