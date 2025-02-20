using DAY1;
using DAY3.Additional_Task_Classes;
using DAY3.Classes;
using DAY3.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISaveFile,SaveFile>();
builder.Services.AddScoped<IOpenWeather,OpenWeatherClass>();

builder.Services.AddSingleton<IGuidSingleton, GuidClass>();
builder.Services.AddTransient<IGuidTransient, GuidClass>();
builder.Services.AddScoped<IGuidScoped, GuidClass>();


var app = builder.Build();

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