using MediatR;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Authentication.SignIn;

public sealed record SignInRequest(string Login, string Password) : IRequest<Result<string>>;