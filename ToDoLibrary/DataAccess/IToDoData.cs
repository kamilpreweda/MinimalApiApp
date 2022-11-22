using ToDoLibrary.Models;

namespace ToDoLibrary.DataAccess
{
    public interface IToDoData
    {
        Task CompleteToDo(int assignedTo, int toDoId);
        Task<ToDoModel?> Create(int assignedTo, string task);
        Task Delete(int assignedTo, int toDoId);
        Task<List<ToDoModel>> GetAllAssigned(int assignedTo);
        Task<ToDoModel?> GetOneAssigned(int assignedTo, int toDoId);
        Task UpdateTask(int assignedTo, int toDoId, string task);
    }
}