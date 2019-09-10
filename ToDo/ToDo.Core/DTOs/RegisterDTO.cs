using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
