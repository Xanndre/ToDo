﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Core.DTOs
{
    public class TodoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
