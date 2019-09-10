using System.ComponentModel.DataAnnotations;
using ToDo.Core.Utils;

namespace ToDo.Core.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = DictionaryResources.PasswordLength, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
