using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Core.DTOs;

namespace ToDo.Core.Interfaces
{
    public interface ITodoService
    {
        Task<TodoDTO> CreateTodo(TodoDTO todo);
        Task DeleteTodo(int id);
        Task<IEnumerable<TodoDTO>> GetUserTodos(string userId);
    }
}
