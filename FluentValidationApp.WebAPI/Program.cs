using FluentValidation.AspNetCore;
using FluentValidationApp.WebAPI.Models.Context;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews().AddFluentValidation(options =>
{
    //birden fazla validation iþlemi söz konusu ise bunu kullanmak daha mantýklýdýr.
    options.RegisterValidatorsFromAssemblyContaining<Program>();

});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

////1.Yöntem Veritabanýna bðlank için kullanýlýyor
builder.Services.AddDbContext<AppDatabaseContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
