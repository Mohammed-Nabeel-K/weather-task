using Microsoft.EntityFrameworkCore;
using System;
using Weather.BLL.Interfaces;
using Weather.BLL.Services;
using Weather.DAL.Data;
using Weather.DAL.External.API;
using Weather.DAL.Interfaces;
using Weather.DAL.Models;
using Weather.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IOpenWeather, OpenWeather>();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

builder.Services.AddHttpClient();

builder.Services.Configure<WeatherSettings>(
    builder.Configuration.GetSection("WeatherSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // your React app port
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
