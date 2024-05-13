using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.UpdateName;

public sealed record UpdateWorkshopNameRequest(Guid Id, string Name) : IRequest<Result>;