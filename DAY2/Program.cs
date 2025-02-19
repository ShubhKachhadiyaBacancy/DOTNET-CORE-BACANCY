using DAY2.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRequestLoggerMiddleware();
app.UseErrorHandlingMiddleware();

IConfiguration configuration = app.Configuration;
//string id1 = configuration.GetSection("Tokens:id1").Value;
//string id2 = configuration.GetSection("Tokens:id2").Value;
//string id3 = configuration.GetSection("Tokens:id3").Value;
//Console.WriteLine($"ID1 : {id1}\nID2 : {id2}\nID3 : {id3}");

string id1 = configuration.GetSection("Tokens:id1").Value;
string id2 = configuration.GetSection("Tokens:id2").Value;
string id3 = configuration.GetSection("Tokens:id3").Value;
Console.WriteLine($"ID1 : {id1}\nID2 : {id2}\nID3 : {id3}");

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("ConfigureCors", policy =>
//    {

//    });
//});

//app.UseCors("ConfigureCors");

app.Use(async (context, next) =>
{
    Console.WriteLine("USE MIDDLEWARE");
    await context.Response.WriteAsync("USE MIDDLEWARE\n");
    await next();
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("RUN MIDDLEWARE\n");
    Console.WriteLine("RUN MIDDLEWARE");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();  

app.UseAuthorization();

app.MapControllers();

app.Run();
