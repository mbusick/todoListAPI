using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Todo> PostTodo(Todo request)
        {
            await _todosCollection.InsertOneAsync(request);
            
            return request;
        }
    }
}