using MediatR;
using Microsoft.Extensions.Logging;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supplier.NewSupplier;

public sealed class NewSupplierHandler(
    IGenericRepository<SupplierEntity> repository,
    ILogger<NewSupplierHandler> logger)
    : IRequestHandler<NewSupplierRequest, Result<Guid>>
{
    private const string CantCreateNewSupplierError = "Can't create new supplier.";

    public async Task<Result<Guid>> Handle(NewSupplierRequest request, CancellationToken cancellationToken)
    {
        SupplierEntity dbRecord = new SupplierEntity()
        {
            Address = request.Address,
            Name = request.Name
        };

        try
        {
            await repository.Create(dbRecord, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError($"Can't create new Supplier with address [{request.Address}] and name [{request.Name}]: {ex.Message}");
            return Result<Guid>.Error(CantCreateNewSupplierError);
        }
        return Result<Guid>.Success(dbRecord.Id);
    }
}