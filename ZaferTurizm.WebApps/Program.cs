using Microsoft.EntityFrameworkCore;
using ZaferTurizm.Bussiness.Services;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Bussiness;
using ZaferTurizm.DataAccess.Settings;
using ZaferTurizm.Domain;
using System.Reflection;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var context = builder.Configuration.GetConnectionString("BinteConnetion");
// Add services to the container.
builder.Services.AddControllersWithViews();
Trace.Listeners.Add(new TextWriterTraceListener("error-logs.txt"));//hatalarý yazdýrma
Trace.AutoFlush = true;

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TourDbContext>(p =>
{
    p.UseSqlServer(context);
});
builder.Services.AddScoped<IVehicleMakeService, VehicleMakeService>();
builder.Services.AddScoped<IVehicleModelService, VehicleModelService>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<IVehicleDefintionService, VehicleDefintionService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IRotaService, RotaService>();
builder.Services.AddScoped<IHumanService, HumanService>();
builder.Services.AddScoped<IBusTripService, BusTripService>();
builder.Services.AddScoped<IBiletService, BiletService>();

//builder.Services.AddScoped<TourDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
