using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supplier.RemoveSupplier;

public sealed record RemoveSupplierRequest(Guid SupplierId) : IRequest<Result>;