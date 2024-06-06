using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.UpdateName;

public sealed class UpdateProductNameHandler(
    IGenericRepository<ProductEntity> repository)
    : IRequestHandler<UpdateProductNameRequest, Result>
{
    private const string ProductNotFoundError = "Product not found.";
    private const string UpdateError = "Error while update product name.";

    public async Task<Result> Handle(UpdateProductNameRequest request, CancellationToken cancellationToken)
    {
        ProductEntity? dbRecord = await repository.GetById(request.Id);
        if (dbRecord is null)
        {
            return Result.Error(ProductNotFoundError);
        }

        dbRecord.Name = request.Name;

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