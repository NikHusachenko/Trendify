using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.HttServices;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Services.UserServices;

public sealed class CurrentUserContext : ICurrentUserContext
{
    private const string IdentityUserUrl = "https://localhost:7059/api/authentication/current-user";
    private const string AuthenticationScheme = "Bearer";
    private const string UserNotFoundError = "User not found.";
    private const string UnauthorizedError = "Unauthorized";

    private readonly HttpContext _context;

    public CurrentUserContext(IHttpContextAccessor contextAccessor)
    {
        _context = contextAccessor.HttpContext;
    }

    public async Task<Result<UserEntity>> GetCurrentUser()
    {
        HttpRequest request = _context.Request;
        string? token = TokenExtractor.ExtractToken(request.Headers);

        if (string.IsNullOrEmpty(token))
        {
            Result<UserEntity>.Error(UnauthorizedError);
        }

        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, IdentityUserUrl);
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue(AuthenticationScheme, token);

        using HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

        if (!response.IsSuccessStatusCode)
        {
            return Result<UserEntity>.Error(UserNotFoundError);
        }

        string json = await response.Content.ReadAsStringAsync();

        try
        {
            UserEntity? user = JsonConvert.DeserializeObject<UserEntity>(json);
            return user is null ?
                Result<UserEntity>.Error(UserNotFoundError) :
                Result<UserEntity>.Success(user);
        }
        catch
        {
            return Result<UserEntity>.Error(UserNotFoundError);
        }
    }
}