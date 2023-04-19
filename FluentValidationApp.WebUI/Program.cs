using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationApp.WebUI.FluentValidations;
using FluentValidationApp.WebUI.Models;
using FluentValidationApp.WebUI.Models.Context;
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
////1.Yöntem
builder.Services.AddDbContext<AppDatabaseContext>();


//ya da Fluent iþlemi için 1 tane için yapýlabilir ama çok sayýda varsa üstteki kodu yazmak daha effective
//builder.Services.AddSingleton<IValidator<Customer>, CustomerValidator>();

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
