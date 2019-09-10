using ToDo.Data;

namespace ToDo.Repositories.Repositories
{
    public class BaseRepository
    {
        protected ToDoDbContext _toDoDbContext;
        public BaseRepository(ToDoDbContext dbContext)
        {
            _toDoDbContext = dbContext;
        }
    }
}
