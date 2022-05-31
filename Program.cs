using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TaskDB"));
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("cnTask")); //Obtener los datos de conexión del appsetting.json

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TaskContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Data base is in memory: " + dbContext.Database.IsInMemory());
});

app.Run();
