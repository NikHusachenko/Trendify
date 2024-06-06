using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.GetById;

public sealed class GetProductByIdHandler(IGenericRepository<ProductEntity> repository) 
    : IRequestHandler<GetProductByIdRequest, Result<ProductEntity>>
{
    private const string NotFoundError = "Product not found.";

    public async Task<Result<ProductEntity>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        ProductEntity? dbRecord = await repository.GetById(request.Id);
        if (dbRecord is null)
        {
            return Result<ProductEntity>.Error(NotFoundError);
        }
        return Result<ProductEntity>.Success(dbRecord);
    }
}