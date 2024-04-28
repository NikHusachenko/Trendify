using MediatR;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.Domain.Handler.Supplier.GetSuppliers;

public sealed class GetSuppliersRequest : IRequest<List<SupplierEntity>>;