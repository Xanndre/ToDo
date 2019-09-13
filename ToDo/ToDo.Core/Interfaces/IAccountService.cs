using System.Threading.Tasks;
using ToDo.Core.DTOs;
using ToDo.Data.Entities;

namespace ToDo.Core.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResultDTO> Login(LoginDTO dto);
        Task Register(RegisterDTO dto);
        string GenerateJwtToken(ApplicationUser user);
    }
}
