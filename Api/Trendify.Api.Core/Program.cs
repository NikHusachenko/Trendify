using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Trendify.Api.Domain.Handler.Supplier.NewSupplier;
using Trendify.Api.EntityFramework;
using Trendify.Api.EntityFramework.Repository;
using Trendify.Api.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7015")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
});
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

services.AddSignalR();
services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(NewSupplierRequest).Assembly));

services.AddHttpContextAccessor();
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