using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Authentication.CurrentUser;

public sealed record GetCurrentUserRequest : IRequest<Result<UserEntity>>;