using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.DTOs;
using ToDo.Core.Interfaces;

namespace ToDo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost]
        public async Task<ActionResult<TodoDTO>> CreateTodo([FromBody] TodoDTO todo)
        {
            try
            {
                var createdTodo = await _todoService.CreateTodo(todo);
                return Ok(createdTodo);
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            try
            {
                await _todoService.DeleteTodo(id);
                return Ok();
            }
            catch(ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("user/{username}")]
        public async Task<ActionResult<IEnumerable<TodoDTO>>> GetUserTodos(string username)
        {
            try
            {
                return Ok(await _todoService.GetUserTodos(username));
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
