using MediatR;
using Trendify.Api.Database.Entities;
using Trendify.Api.Services.Response;

namespace Trendify.Api.Domain.Handler.Authentication.SignUp;

public sealed record SignUpRequest(string FirstName, string LastName, string MiddleName, string Login, string Password, Guid WorkshopId)
    : IRequest<Result<string>>;