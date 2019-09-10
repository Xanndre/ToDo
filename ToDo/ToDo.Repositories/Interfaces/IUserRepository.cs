using System.Threading.Tasks;

namespace ToDo.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<string> GetUserId(string username);
    }
}
