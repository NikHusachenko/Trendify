﻿using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Supply.RemoveMaterialFromSupply;

public sealed record RemoveMaterialFromSupplyRequest(Guid SupplyId, Guid MaterialId) : IRequest<Result>;