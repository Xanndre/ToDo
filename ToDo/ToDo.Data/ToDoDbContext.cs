using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Data.Entities;

namespace ToDo.Data
{
    public class ToDoDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Todo> Todos { get; set; }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }
    }
}
