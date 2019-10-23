using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoListAPI.Models;
using todoListAPI.Orchestrator;

namespace todoListAPI.Controller
{
    public class TodoController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ITodoOrchestrator _orchestrator;

        public TodoController(ITodoOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        [HttpGet("todos")]
        public async Task<List<Todo>> GetTodos()
        {
            var todos = await _orchestrator.GetTodos();
            return todos;
        }

        [HttpPost("todos")]
        public async Task<Todo> PostTodo(TodoRequest request)
        {
            var result = await _orchestrator.PostTodo(request);
            return result;
        }
    }
}