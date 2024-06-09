using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Identity.Api.Services.UserServices;

public interface ICurrentUserContext
{
    Task<Result<UserEntity>> CurrentUser();
}