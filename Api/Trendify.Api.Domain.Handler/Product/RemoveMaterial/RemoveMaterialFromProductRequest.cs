﻿using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Product.RemoveMaterial;

public sealed record RemoveMaterialFromProductRequest(Guid ProductId, Guid MaterialId) : IRequest<Result>;