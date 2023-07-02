using Microsoft.EntityFrameworkCore;
using ZaferTurizm.DataAccess;

var builder = WebApplication.CreateBuilder(args);


//var context = builder.Configuration.GetConnectionString("BinteConnetion");
//builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<TourDbContext>(p =>
//{
//    p.UseSqlServer(context);
//});


var app = builder.Build();

app.UseAuthentication();
//app.UseAuthorization();
app.UseStaticFiles();

app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");

app.Run();