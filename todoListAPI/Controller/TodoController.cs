using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        public async Task<Todo> PostTodo([FromBody] TodoRequest request)
        {
            var result = await _orchestrator.PostTodo(request);
            return result;
        }

        [HttpPut("todos/{id}")]
        public async Task<Todo> PutTodo([FromBody]EditTodoRequest edit, [FromRoute] string id)
        {
            var result = await _orchestrator.PutTodo(edit, id);
            return result;
        }
        
        [HttpDelete("todos")]
        public async Task<ActionResult> DeleteTodo()
        {
            await _orchestrator.DeleteAll();
            return NoContent();
        }

        [HttpDelete("todos/{id}")]
        public async Task<ActionResult> DeleteTodo([FromRoute] string id)
        {
            await _orchestrator.DeleteTodo(id);
            return NoContent();
        }
    }
}