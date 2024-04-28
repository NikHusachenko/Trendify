using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supplier.UpdateSupplierAddress;

public sealed record UpdateSupplierAddressRequest(Guid SupplierId, string Address) : IRequest<Result>;