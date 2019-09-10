using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Repositories.Interfaces;

namespace ToDo.Repositories.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ToDoDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<string> GetUserId(string username)
        {
            var user = await _toDoDbContext.Users.FirstAsync(u => u.UserName == username);
            return user.Id;
        }
    }
}
