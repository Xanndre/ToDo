﻿using Microsoft.AspNetCore.Identity;

namespace ToDo.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
