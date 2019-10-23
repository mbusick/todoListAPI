using System.Collections.Generic;
using System.Threading.Tasks;
using todoListAPI.Models;

namespace todoListAPI.Repository
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetTodos();

        Task<Todo> PostTodo(Todo request);
    }
}