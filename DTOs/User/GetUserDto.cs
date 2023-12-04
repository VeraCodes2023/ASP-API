using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.DTOs.User
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Role Role { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Avatar { get; set; }

    }
}