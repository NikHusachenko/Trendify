using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.UpdateShortDescription;

public sealed class UpdateProductShortDescriptionHandler(
    IGenericRepository<ProductEntity> repository)
    : IRequestHandler<UpdateProductShortDescriptionRequest, Result>
{
    private const string NotFoundError = "Product not found.";
    private const string UpdateError = "Error while update product short description.";

    public async Task<Result> Handle(UpdateProductShortDescriptionRequest request, CancellationToken cancellationToken)
    {
        ProductEntity? dbRecord = await repository.GetById(request.Id);
        if (dbRecord is null)
        {
            return Result.Error(NotFoundError);
        }

        dbRecord.ShortDescription = request.ShortDescription;

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