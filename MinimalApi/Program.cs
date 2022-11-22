using ToDoLibrary.DataAccess;
using ToDoLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using MinimalApi.Endpoints;

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

app.AddTodoEndpoints();

app.Run();