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
    }
}
