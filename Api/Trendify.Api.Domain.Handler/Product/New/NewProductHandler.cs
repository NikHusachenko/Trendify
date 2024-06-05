using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Database.Enums;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.New;

public sealed class NewProductHandler(
    IGenericRepository<ProductEntity> repository)
    : IRequestHandler<NewProductRequest, Result<ProductEntity>>
{
    private const string WasCreatedError = "Product with same name was created.";
    private const string CreationError = "Error while create new product.";

    private const float DEFAULT_PRICE = 0f;

    public async Task<Result<ProductEntity>> Handle(NewProductRequest request, CancellationToken cancellationToken)
    {
        ProductEntity? dbRecord = await repository.GetBy(product => product.Name == request.Name);
        if (dbRecord is not null)
        {
            return Result<ProductEntity>.Error(WasCreatedError);
        }

        dbRecord = new ProductEntity()
        {
            Name = request.Name,
            Description = request.Description,
            Price = DEFAULT_PRICE,
            ShortDescription = request.ShortDescription,
        };

        try
        {
            await repository.Create(dbRecord);
        }
        catch
        {
            return Result<ProductEntity>.Error(CreationError);
        }
        return Result<ProductEntity>.Success(dbRecord);
    }
}