using Microsoft.EntityFrameworkCore;
using Trendify.Api.Core.Attributes;
using Trendify.Api.Domain.Handler.Supplier.NewSupplier;
using Trendify.Api.EntityFramework;
using Trendify.Api.EntityFramework.Repository;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers(configuration =>
{
/*    configuration.Filters.Add(new IdentityAuthorizeAttribute());
    configuration.Filters.Add(new IdentityAnonymousAttribute());*/
});
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
});
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

services.AddSignalR();
services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(NewSupplierRequest).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
