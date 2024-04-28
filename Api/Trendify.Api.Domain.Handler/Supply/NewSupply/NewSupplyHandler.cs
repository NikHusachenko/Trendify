using MediatR;
using Microsoft.Extensions.Logging;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.NewSupply;

public sealed class NewSupplyHandler(
    IGenericRepository<SupplyEntity> repository,
    ILogger<NewSupplyHandler> logger)
    : IRequestHandler<NewSupplyRequest, Result<Guid>>
{
    private const string CantCreateNewSupplyError = "Can't create new supply.";

    public async Task<Result<Guid>> Handle(NewSupplyRequest request, CancellationToken cancellationToken)
    {
        SupplyEntity entity = new SupplyEntity()
        {
            SupplierId = request.SupplierId,
        };

        try
        {
            await repository.Create(entity, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError($"Can't create new supply: {ex.Message}");
            return Result<Guid>.Error(CantCreateNewSupplyError);
        }
        return Result<Guid>.Success(entity.Id);
    }
}