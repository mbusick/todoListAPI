using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using todoListAPI.Models;

namespace todoListAPI.Orchestrator
{
    public interface ITodoOrchestrator
    {
        Task<List<Todo>> GetTodos();
        Task<Todo> PostTodo(TodoRequest request);
        Task<Todo> PutTodo(EditTodoRequest edit, string id);
        Task DeleteTodo(string id);
        Task DeleteAll();

    }
}