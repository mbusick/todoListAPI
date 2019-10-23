using System.Collections.Generic;
using System.Threading.Tasks;
using todoListAPI.Models;
using todoListAPI.Repository;

namespace todoListAPI.Orchestrator
{
    public class TodoOrchestrator : ITodoOrchestrator
    {
        private readonly ITodoRepository _repository;

        public TodoOrchestrator(ITodoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Todo>> GetTodos()
        {
            var repositoryResult = await _repository.GetTodos();
            return repositoryResult;
        }

        public async Task<Todo> PostTodo(TodoRequest request)
        {
            var todo = new Todo
            {
                Task = request.Task,
                Date = request.Date,
                Status = request.Status
            };
            
            var response = await _repository.PostTodo(todo);
            return response;
        }
    }
}