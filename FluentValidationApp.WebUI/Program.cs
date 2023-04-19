using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationApp.WebUI.FluentValidations;
using FluentValidationApp.WebUI.Models;
using FluentValidationApp.WebUI.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews().
//Fluent i�lemlerinin ger�ekle�mesi i�in eklenecek kod blo�u a�a���da olu�turulmu�tue
builder.Services.AddControllersWithViews().AddFluentValidation(options =>
{
    //birden fazla validation i�lemi s�z konusu ise bunu kullanmak daha mant�kl�d�r.
    options.RegisterValidatorsFromAssemblyContaining<Program>();

});
////1.Y�ntem
builder.Services.AddDbContext<AppDatabaseContext>();


//ya da Fluent i�lemi i�in 1 tane i�in yap�labilir ama �ok say�da varsa �stteki kodu yazmak daha effective
//builder.Services.AddSingleton<IValidator<Customer>, CustomerValidator>();

var app = builder.Build();

////2.Y�ntem
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
