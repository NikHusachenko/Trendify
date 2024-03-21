using Microsoft.EntityFrameworkCore;
using Trendify.EntityFramework;
using Trendify.EntityFramework.Repository;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllersWithViews();

services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
