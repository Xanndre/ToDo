using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Data.Entities;

namespace ToDo.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> CreateTodo(Todo todo);
        Task DeleteTodo(Todo todo);
        Task<Todo> GetTodo(int id);
        Task<IEnumerable<Todo>> GetUserTodos(string userId);
    }
}
