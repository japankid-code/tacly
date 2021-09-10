using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backendv3.Models
{
    public class User : IdentityUser
    {
        public User() { }
        public User(CreateUserRequest create)
        {
            UserName = create.UserName;
            Email = create.Email;
        }
        public ICollection<User> Friends { get; set; }
        public List<Game> Games { get; set; }
    }

    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public static implicit operator LoginUserRequest(CreateUserRequest model)
        {
            return new LoginUserRequest { UserName = model.UserName, Password = model.Password };
        }
    }
}
