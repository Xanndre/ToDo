using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Data.Entities;
using ToDo.Repositories.Interfaces;

namespace ToDo.Repositories.Repositories
{
    public class TodoRepository : BaseRepository, ITodoRepository
    {
        public TodoRepository(ToDoDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Todo> CreateTodo(Todo todo)
        {
            await _toDoDbContext.Todos.AddAsync(todo);
            await _toDoDbContext.SaveChangesAsync();
            return todo;
        }

        public async Task DeleteTodo(Todo todo)
        {
            _toDoDbContext.Todos.Remove(todo);
            await _toDoDbContext.SaveChangesAsync();
        }

        public async Task<Todo> GetTodo(int id)
        {
            return await _toDoDbContext.Todos
                .FirstAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Todo>> GetUserTodos(string userId)
        {
            return await _toDoDbContext.Todos
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
    }
}
