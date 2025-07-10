
using Microsoft.EntityFrameworkCore;
using Speedy_Groceries;
using Speedy_Groceries.DataMethods;
using Speedy_Groceries.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IMath,BasicMath>();
//builder.Services.AddScoped<IMath, BasicMath>();
//builder.Services.AddSingleton<IMath, BasicMath>();

var SqlConnect = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDataBaseContext>(options => options.UseSqlServer(SqlConnect));
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseStaticFiles();
app.Run();


