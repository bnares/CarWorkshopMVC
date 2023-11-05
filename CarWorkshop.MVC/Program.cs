using CarWorkshopMVC.Application.Extensions;
using CarWorkshopMVC.Application.Services;
using CarWorkshopMVC.Infrastructure.Extensions;
using CarWorkshopMVC.Infrastructure.Persistance;
using CarWorkshopMVC.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICarWorkshopService, CarWorkshopService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//in Infrastructure i created my own extension method -AddInfrastructure which deal with the commented code below
builder.Services.AddInfrastructure(builder.Configuration);

//builder.Services.AddDbContext<CarWorkshopDbContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("CarWorkshop")));
builder.Services.AddApplication();

var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<CarWorkshopSeeder>();
await seeder.Seed();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
