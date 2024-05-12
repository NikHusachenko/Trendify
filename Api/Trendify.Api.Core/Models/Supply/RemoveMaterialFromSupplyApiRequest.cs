using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Core.Models.Supply;

public sealed record RemoveMaterialFromSupplyApiRequest(Guid Id) : IRequest<Result>;