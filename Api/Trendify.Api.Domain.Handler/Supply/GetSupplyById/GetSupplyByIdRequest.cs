using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.GetSupplyById;

public sealed record GetSupplyByIdRequest(Guid SupplierId, Guid SupplyId) : IRequest<Result<SupplyEntity>>;