using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.UpdateInfo;

public sealed record UpdateWorkshopInfoRequest(Guid Id, string City, string Street, string LocalAddress) : IRequest<Result>;