using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Role Role { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Avatar { get; set; }
        public User(){}
        public User(int id, string name= "", Role role = Role.Customer, string email="", string password="", string avatar="")
        {
            this.Id = id;
            this.Name = name;
            this.Role = role;
            this.Email =email;
            this.Password = password;
            this.Avatar = avatar;
        }
        

    }
}