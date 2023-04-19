using FluentValidationApp.WebUI.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
////1.Yöntem
builder.Services.AddDbContext<AppDatabaseContext>();

var app = builder.Build();

////2.Yöntem
//builder.Services.AddDbContext<AppDatabaseContext>(options =>
//{
//    options.UseSqlServer(app.Configuration["FluentConnectionStrings"]);
//});

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
