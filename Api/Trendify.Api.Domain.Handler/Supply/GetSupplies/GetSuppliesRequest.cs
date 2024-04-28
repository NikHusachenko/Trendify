using MediatR;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.Domain.Handler.Supply.GetSupplies;

public sealed record GetSuppliesRequest(Guid supplierId) : IRequest<List<SupplyEntity>>;