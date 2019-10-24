using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using todoListAPI.Models;
using todoListAPI.Orchestrator;

namespace todoListAPI.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IMongoCollection<Todo> _todosCollection;

        public TodoRepository(IMongoDatabase mongoDatabase)
        {
            _todosCollection = mongoDatabase.GetCollection<Todo>("todosCollection");
        }

        public async Task<List<Todo>> GetTodos()
        {
            var result = await _todosCollection.AsQueryable().ToListAsync();
            return result;
        }
        
        public async Task<Todo> GetTodo(string id)
        {
            var result = await _todosCollection.Find(x => x.TodoId == id).SingleAsync();
            return result;
        }

        public async Task<Todo> PostTodo(Todo request)
        {
            await _todosCollection.InsertOneAsync(request);
            
            return request;
        }

        public async Task DeleteTodo(string id)
        {
            await _todosCollection.DeleteOneAsync(a => a.TodoId == id);
        }
        public async Task DeleteAll()
        {
            await _todosCollection.DeleteManyAsync(x => x.ObjectId != null);
        }

        public async Task<Todo> PutTodo(EditTodoRequest edit, Todo newTodo)
        {
            await _todosCollection.ReplaceOneAsync(x => x.TodoId == newTodo.TodoId, newTodo);
            return await GetTodo(newTodo.TodoId);
        }
    }
}