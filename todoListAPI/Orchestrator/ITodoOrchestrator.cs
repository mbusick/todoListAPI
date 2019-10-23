using System.Collections.Generic;
using System.Threading.Tasks;
using todoListAPI.Models;

namespace todoListAPI.Orchestrator
{
    public interface ITodoOrchestrator
    {
        Task<List<Todo>> GetTodos();
        Task<Todo> PostTodo(TodoRequest request);
    }
}