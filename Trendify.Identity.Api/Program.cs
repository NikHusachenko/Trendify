using Microsoft.EntityFrameworkCore;
using Trendify.Api.EntityFramework;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Identity.Api.Services.AuthenticationServices;
using Trendify.Identity.Api.Services.JwtTokenServices;
using Trendify.Identity.Api.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy
        .WithOrigins("https://localhost:7054", "http://localhost:5045")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]));
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

services.AddHttpContextAccessor();
services.AddTransient<IJwtTokenService, JwtTokenService>();
services.AddTransient<IAuthenticationService, AuthenticationService>();
services.AddScoped<ICurrentUserContext, CurrentUserContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();