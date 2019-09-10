using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ToDo.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}
