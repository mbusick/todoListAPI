using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using todoListAPI.Models;

namespace todoListAPI.Repository
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetTodos();

        Task<Todo> PostTodo(Todo request);
        Task DeleteTodo(string id);
        Task DeleteAll();

        Task<Todo> PutTodo(EditTodoRequest edit, Todo newTodo);
        Task<Todo> GetTodo(string id);
    }
}