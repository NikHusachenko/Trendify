using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supplier.GetSupplierById;

public sealed record GetSupplierByIdRequest(Guid Id) : IRequest<Result<SupplierEntity>>;