using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.HttServices;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supplier.NewSupplier;

public sealed class NewSupplierHandler(
    IGenericRepository<SupplierEntity> supplierRepository,
    IGenericRepository<CredentialsEntity> credentialsRepository,
    ILogger<NewSupplierHandler> logger,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<NewSupplierRequest, Result<Guid>>
{
    private const string InvalidCredentialsError = "Invalid credentials.";

    public async Task<Result<Guid>> Handle(NewSupplierRequest request, CancellationToken cancellationToken)
    {
        string? token = TokenExtractor.ExtractToken(httpContextAccessor.HttpContext.Request.Headers);
        if (string.IsNullOrWhiteSpace(token))
        {
            return Result<Guid>.Error(InvalidCredentialsError);
        }

        CredentialsEntity? credentials = await credentialsRepository.GetBy(c => c.AuthenticationTokens.FirstOrDefault(t => t.Token == token) != null);
        if (credentials is null)
        {
            return Result<Guid>.Error(InvalidCredentialsError);
        }

        SupplierEntity dbRecord = new SupplierEntity()
        {
            Address = request.Address,
            Name = request.Name,
            CredentialsId = credentials.Id,
        };

        try
        {
            await supplierRepository.Create(dbRecord);
        }
        catch (Exception ex)
        {
            logger.LogError($"Can't create new Supplier with address [{request.Address}] and name [{request.Name}]: {ex.Message}");
            return Result<Guid>.Error(ex);
        }
        return Result<Guid>.Success(dbRecord.Id);
    }
}