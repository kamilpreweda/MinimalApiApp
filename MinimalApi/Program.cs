using ToDoLibrary.DataAccess;
using ToDoLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IToDoData, ToDoData>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/Todos", async (IToDoData data) =>
{
    var output = await data.GetAllAssigned(1);
    return Results.Ok(output);
});

app.MapPost("/api/Todos", async (IToDoData data, [FromBody] string task) =>
{
    var output = await data.Create(1, task);
    return Results.Ok(output);
});

app.Run();