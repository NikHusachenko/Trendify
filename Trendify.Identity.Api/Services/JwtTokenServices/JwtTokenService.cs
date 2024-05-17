using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.Response;
using Trendify.Identity.Api.Services.AuthenticationServices;

namespace Trendify.Identity.Api.Services.JwtTokenServices;

public sealed class JwtTokenService : IJwtTokenService
{
    private const string CantReadTokenError = "Can't read token.";
    private const string IncorrectTokenError = "Incorrect token.";
    private const string TokenDisabledError = "Token disabled.";
    private const string ErrorWhileDisabling = "Error while token disabling.";
    private const string CredentialsNotFoundError = "Credentials not found.";

    private readonly JwtOptions _jwtOptions;
    private readonly JwtSecurityTokenHandler _securityTokenHandler;
    private readonly IGenericRepository<AuthenticationTokenEntity> _repository;

    public JwtTokenService(IOptionsMonitor<JwtOptions> monitor, 
        IGenericRepository<AuthenticationTokenEntity> repository)
    {
        _jwtOptions = monitor.CurrentValue;
        _securityTokenHandler = new JwtSecurityTokenHandler();
        _repository = repository;
    }

    public async Task<Result> CheckAccess(string token)
    {
        AuthenticationTokenEntity? authenticationToken = await _repository.GetBy(entity => entity.Token == token);
        if (authenticationToken is null)
        {
            return Result.Error(IncorrectTokenError);
        }

        if (authenticationToken!.Expiration <= DateTime.Now.ToUniversalTime())
        {
            authenticationToken.IsActive = false;
            try
            {
                await _repository.Update(authenticationToken);
            }
            catch { }

            return Result.Error(TokenDisabledError);
        }

        return Result.Success();
    }

    public Result<IEnumerable<Claim>> Decode(string token) =>
        _securityTokenHandler.CanReadToken(token) ?
            Result<IEnumerable<Claim>>.Success(_securityTokenHandler.ReadJwtToken(token).Claims) :
            Result<IEnumerable<Claim>>.Error(CantReadTokenError);

    public async Task<Result> DisableToken(string token)
    {
        AuthenticationTokenEntity? authenticationToken = await _repository.GetBy(entity => entity.Token == token);
        if (authenticationToken is null)
        {
            return Result.Error(IncorrectTokenError);
        }

        authenticationToken.IsActive = false;

        try
        {
            await _repository.Update(authenticationToken);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Error(ErrorWhileDisabling);
        }
    }

    public async Task<Result<string>> Encode(IEnumerable<Claim> claims)
    {
        if (!TryFindId(claims, out Guid id))
        {
            return Result<string>.Error(CredentialsNotFoundError);
        }

        AuthenticationTokenEntity entity = new()
        {
            CredentialsId = id,
            Expiration = DateTime.Now.AddSeconds(_jwtOptions.Expiration).ToUniversalTime(),
            IsActive = true,
        };

        byte[] byteKey = Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey);
        SecurityKey key = new SymmetricSecurityKey(byteKey);
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        SecurityToken securityToken = new JwtSecurityToken(
            claims: claims,
            signingCredentials: credentials,
            expires: DateTime.Now.AddSeconds(_jwtOptions.Expiration));

        try
        {
            entity.Token = _securityTokenHandler.WriteToken(securityToken);
            await _repository.Create(entity);
            return Result<string>.Success(entity.Token);
        }
        catch (Exception ex)
        {
            return Result<string>.Error(ex.Message);
        }
    }

    private bool TryFindId(IEnumerable<Claim> claims, out Guid id)
    {
        string? value = claims.FirstOrDefault(claim => claim.Type == JwtClaimTypes.Id.ToString())?.Value;
        if (string.IsNullOrWhiteSpace(value))
        {
            id = Guid.Empty;
            return false;
        }

        if (Guid.TryParse(value, out Guid _id))
        {
            id = Guid.Empty;
            return false;
        }

        id = _id;
        return true;
    }
}