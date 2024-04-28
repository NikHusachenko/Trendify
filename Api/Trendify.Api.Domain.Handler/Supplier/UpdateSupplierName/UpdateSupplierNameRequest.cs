using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supplier.UpdateSupplierName;

public sealed record UpdateSupplierNameRequest(Guid Id, string Name) : IRequest<Result>;