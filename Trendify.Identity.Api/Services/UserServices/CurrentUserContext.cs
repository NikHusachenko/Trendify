using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Extensions;
using Trendify.Api.Services.HttServices;
using Trendify.Api.Services.Response;
using Trendify.Identity.Api.Services.AuthenticationServices;
using Trendify.Identity.Api.Services.JwtTokenServices;

namespace Trendify.Identity.Api.Services.UserServices;

public sealed class CurrentUserContext : ICurrentUserContext
{
    private const string CONTEXT_NOT_AVAILABLE_ERROR = "Http data not available.";

    private readonly HttpContext _context;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IGenericRepository<UserEntity> _repository;

    public CurrentUserContext(IHttpContextAccessor contextAccessor, 
        IJwtTokenService jwtTokenService,
        IGenericRepository<UserEntity> repository)
    {
        _context = contextAccessor.HttpContext ??
            throw new HttpRequestException(CONTEXT_NOT_AVAILABLE_ERROR);

        _jwtTokenService = jwtTokenService;
        _repository = repository;
    }

    public async Task<Result<UserEntity>> CurrentUser()
    {
        string token = _context.Request.Headers.Authorization.ToString().Split(' ').Last();
        if (string.IsNullOrEmpty(token))
        {
            return Result<UserEntity>.Error(CONTEXT_NOT_AVAILABLE_ERROR);
        }

        UserEntity? dbRecord = await _repository.GetAllBy(
            entity => entity.Credentials.AuthenticationTokens
                .FirstOrDefault(t => t.Token == token) != null)
            .Include(entity => entity.Credentials)
            .FirstOrDefaultAsync();

        if (dbRecord is null)
        {
            return Result<UserEntity>.Error(CONTEXT_NOT_AVAILABLE_ERROR);
        }
        return Result<UserEntity>.Success(dbRecord);
    }
}