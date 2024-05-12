using MediatR;
using Trendify.Api.Database.Enums;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Workshop.NewWorkshop;

public sealed record NewWorkshopRequest(string Name,
    WorkshopType Type,
    string City,
    string Street,
    string LocalAddress) : IRequest<Result<Guid>>;