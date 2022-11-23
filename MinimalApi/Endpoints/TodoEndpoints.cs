namespace MinimalApi.Endpoints;

using ToDoLibrary.DataAccess;
using ToDoLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

public static class TodoEndpoints
{
    public static void AddTodoEndpoints(this WebApplication app)
    {
        app.MapGet("/api/Todos", GetAllTodos);
        app.MapPost("/api/Todos", CreateTodo).RequireAuthorization();
        app.MapDelete("/api/Todos/{id}", DeleteTodo).RequireAuthorization();
    }

    [Authorize]
    private async static Task<IResult> GetAllTodos(IToDoData data)
    {
        var output = await data.GetAllAssigned(1);
        return Results.Ok(output);
    }
    private async static Task<IResult> CreateTodo(IToDoData data, [FromBody] string task)
    {
        var output = await data.Create(1, task);
        return Results.Ok(output);
    }
    private async static Task<IResult> DeleteTodo(IToDoData data, int id)
    {
        await data.Delete(1, id);
        return Results.Ok();
    }
}
