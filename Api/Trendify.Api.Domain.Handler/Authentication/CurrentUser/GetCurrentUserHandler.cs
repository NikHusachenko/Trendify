using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;
using Trendify.Api.Services.UserServices;

namespace Trendify.Api.Domain.Handler.Authentication.CurrentUser;

public sealed class GetCurrentUserHandler(
    ICurrentUserContext currentUserContext)
    : IRequestHandler<GetCurrentUserRequest, Result<UserEntity>>
{
    public async Task<Result<UserEntity>> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken) =>
        await currentUserContext.GetCurrentUser();
}