using FluentValidation;
using FluentValidation.AspNetCore;
using AutoMapperApp.WebUI.FluentValidations;
using AutoMapperApp.WebUI.Models;
using AutoMapperApp.WebUI.Models.Context;
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


////1.Y�ntem Veritaban�na b�lank i�in kullan�l�yor
builder.Services.AddDbContext<AppDatabaseContext>();

builder.Services.AddAutoMapper(typeof(Program)); // burada dto lar� tara map i�lemini yap demekteyiz
                                                 // ard�ndan hangi class neye d�n��cekse
                                                 // ayr� bir kasl�r olu�turup mapping i�lemini orada yapmal�

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
