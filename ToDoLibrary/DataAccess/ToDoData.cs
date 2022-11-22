using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoLibrary.Models;

namespace ToDoLibrary.DataAccess
{
    public class ToDoData : IToDoData
    {
        private readonly ISqlDataAccess _sql;

        public ToDoData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public Task<List<ToDoModel>> GetAllAssigned(int assignedTo)
        {
            return _sql.LoadData<ToDoModel, dynamic>(
                "dbo.spToDos_GetAllAssigned",
                new { AssignedTo = assignedTo },
                "Default");
        }

        public async Task<ToDoModel?> GetOneAssigned(int assignedTo, int toDoId)
        {
            var results = await _sql.LoadData<ToDoModel, dynamic>(
                "dbo.spToDos_GetOneAssigned",
                new { AssignedTo = assignedTo, ToDoId = toDoId },
                "Default");
            return results.FirstOrDefault();
        }

        public async Task<ToDoModel?> Create(int assignedTo, string task)
        {
            var results = await _sql.LoadData<ToDoModel, dynamic>(
                "dbo.spToDos_Create",
                new { AssignedTo = assignedTo, Task = task },
                "Default");
            return results.FirstOrDefault();
        }

        public Task UpdateTask(int assignedTo, int toDoId, string task)
        {
            return _sql.SaveData<dynamic>(
                "dbo.spToDos_UpdateTask",
                new { AssignedTo = assignedTo, ToDoId = toDoId, Task = task },
                "Default");
        }

        public Task CompleteToDo(int assignedTo, int toDoId)
        {
            return _sql.SaveData<dynamic>(
                "dbo.spToDos_CompleteToDo",
                new { AssignedTo = assignedTo, ToDoId = toDoId },
                "Default");
        }

        public Task Delete(int assignedTo, int toDoId)
        {
            return _sql.SaveData<dynamic>(
                "dbo.spToDos_Delete",
                new { AssignedTo = assignedTo, ToDoId = toDoId },
                "Default");
        }
    }
}
