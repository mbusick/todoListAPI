using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
            var todoId = Guid.NewGuid().ToString().Split("-").First();
            var todo = new Todo
            {
                Task = request.Task,
                Date = request.Date,
                Status = request.Status,
                TodoId = todoId
            };
            
            var response = await _repository.PostTodo(todo);
            return response;
        }

        public async Task DeleteTodo(string id)
        {
            await _repository.DeleteTodo(id);
        }
        public async Task DeleteAll()
        {
            await _repository.DeleteAll();
        }

        public async Task<Todo> PutTodo(EditTodoRequest edit, string id)
        {
            var originalDoc = await _repository.GetTodo(id);
            var newDoc = new Todo
            {
                ObjectId = originalDoc.ObjectId,
                Task = edit.Task ?? originalDoc.Task,
                Date = edit.Date ?? originalDoc.Date,
                Status = edit.Status ?? originalDoc.Status,
                TodoId = id
            };
            
            return await _repository.PutTodo(edit, newDoc);
        }
    }
}