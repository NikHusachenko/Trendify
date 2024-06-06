using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.UpdateDescription;

public sealed class UpdateProductDescriptionHandler(
    IGenericRepository<ProductEntity> repository)
    : IRequestHandler<UpdateProductDescriptionRequest, Result>
{
    private const string NotFoundError = "Product not found.";
    private const string UpdateError = "Error while update product description.";

    public async Task<Result> Handle(UpdateProductDescriptionRequest request, CancellationToken cancellationToken)
    {
        ProductEntity? dbRecord = await repository.GetById(request.Id);
        if (dbRecord is null)
        {
            return Result.Error(NotFoundError);
        }

        dbRecord.Description = request.Description;

        try
        {
            await repository.Update(dbRecord);
        }
        catch
        {
            return Result.Error(UpdateError);
        }
        return Result.Success();
    }
}