using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.AppendMaterialToSupply;

public sealed record AppendMaterialToSupplyRequest() : IRequest<Result>;