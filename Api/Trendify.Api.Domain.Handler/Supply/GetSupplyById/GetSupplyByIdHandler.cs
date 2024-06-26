﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.GetSupplyById;

public sealed class GetSupplyByIdHandler(
    IGenericRepository<SupplyEntity> repository)
    : IRequestHandler<GetSupplyByIdRequest, Result<SupplyEntity>>
{
    private const string SupplyNotFoundError = "Supply not found.";

    public async Task<Result<SupplyEntity>> Handle(GetSupplyByIdRequest request, CancellationToken cancellationToken) =>
        await repository.GetAllBy(entity => entity.Id == request.SupplyId &&
                entity.SupplierId == request.SupplierId)
            .Include(entity => entity.Materials)
            .FirstOrDefaultAsync()
            .Map(entity => entity is null ?
                Result<SupplyEntity>.Error(SupplyNotFoundError) :
                Result<SupplyEntity>.Success(entity));
}