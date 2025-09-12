﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CreateUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }
        public string Phoneno { get; set; }

        public bool IsValid { get; set; }

        public string Role { get; set; }
    }
}
