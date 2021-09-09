using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backendv3.Models
{
    public class LoginUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
