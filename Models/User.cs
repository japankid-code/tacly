using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backendv3.Models {
    public class ApplicationUser : IdentityUser<Guid> { }
    public class User : ApplicationUser {
        public User() {
            UserGames = new List<UserGame>();
            UserFriends = new List<UserFriend>();
        }

        public User(CreateUserRequest create) {
            UserName = create.UserName;
            Email = create.Email;
        }
        [JsonIgnore]
        public virtual List<UserGame> UserGames { get; set; }
        [NotMapped]
        public virtual List<Game> Games { get; set; }
        [JsonIgnore]
        public virtual List<UserFriend> UserFriends { get; set; }
        [JsonIgnore]
        public virtual List<UserFriend> FriendUsers { get; set; }
        [NotMapped]
        public virtual List<User> Friends => UserFriends
            .Select(uf => uf.Friend)
            .Union(FriendUsers.Select(fu => fu.User)).ToList();

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
