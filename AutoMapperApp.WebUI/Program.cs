using FluentValidation;
using FluentValidation.AspNetCore;
using AutoMapperApp.WebUI.FluentValidations;
using AutoMapperApp.WebUI.Models;
using AutoMapperApp.WebUI.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews().

//Fluent iþlemlerinin gerçekleþmesi için eklenecek kod bloðu aþaððýda oluþturulmuþtue
builder.Services.AddControllersWithViews().AddFluentValidation(options =>
{
    //birden fazla validation iþlemi söz konusu ise bunu kullanmak daha mantýklýdýr.
    options.RegisterValidatorsFromAssemblyContaining<Program>();

});


////1.Yöntem Veritabanýna bðlank için kullanýlýyor
builder.Services.AddDbContext<AppDatabaseContext>();

builder.Services.AddAutoMapper(typeof(Program)); // burada dto larý tara map iþlemini yap demekteyiz
                                                 // ardýndan hangi class neye dönüþcekse
                                                 // ayrý bir kaslör oluþturup mapping iþlemini orada yapmalý

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
