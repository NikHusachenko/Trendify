using MediatR;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.Domain.Handler.Workshop.GetWorkshops;

public sealed record GetWorkshopsRequest : IRequest<List<WorkshopEntity>>;