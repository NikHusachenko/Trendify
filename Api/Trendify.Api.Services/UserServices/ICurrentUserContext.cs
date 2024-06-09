using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Services.UserServices;

public interface ICurrentUserContext
{
    Task<Result<UserEntity>> GetCurrentUser();
}