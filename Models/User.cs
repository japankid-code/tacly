using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace backendv3.Models {
    public class ApplicationUser : IdentityUser<Guid> { }
    public class User : ApplicationUser {
        public User() { }

        public User(CreateUserRequest create) {
            UserName = create.UserName;
            Email = create.Email;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        public virtual List<UserGame> UserGames { get; set; }
        public virtual List<UserFriend> UserFriends { get; set; }
        public virtual IEnumerable<User> Friends => UserFriends.Select(uf => uf.Friend);

    }


    public class CreateUserRequest {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserRequest {
        public string UserName { get; set; }
        public string Password { get; set; }

        public static implicit operator LoginUserRequest(CreateUserRequest model)
        {
            return new LoginUserRequest { UserName = model.UserName, Password = model.Password };
        }
    }
}
