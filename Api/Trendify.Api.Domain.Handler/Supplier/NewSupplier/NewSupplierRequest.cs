using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supplier.NewSupplier;

public sealed record NewSupplierRequest(string Address, string Name) : IRequest<Result<Guid>>;