using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Material.Delete;

public sealed record DeleteMaterialRequest(Guid Id) : IRequest<Result>;