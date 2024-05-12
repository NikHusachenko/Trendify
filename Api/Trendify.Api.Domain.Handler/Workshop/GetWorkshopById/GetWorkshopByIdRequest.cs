using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.GetWorkshopById;

public sealed record GetWorkshopByIdRequest(Guid Id) : IRequest<Result<WorkshopEntity>>;