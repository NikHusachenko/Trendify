using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.Remove;

public sealed record RemoveWorkshopRequest(Guid Id) : IRequest<Result>;