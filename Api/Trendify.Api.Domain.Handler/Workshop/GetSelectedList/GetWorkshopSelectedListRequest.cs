using MediatR;

namespace Trendify.Api.Domain.Handler.Workshop.GetSelectedList;

public sealed record GetWorkshopSelectedListRequest : IRequest<WorkshopSelectedList>;