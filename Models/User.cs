using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backendv3.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            UserGames = new List<UserGame>();
            UserFriends = new List<UserFriend>();
            FriendUsers= new List<UserFriend>();
        }
        public User(CreateUserRequest create)
        {
            UserName = create.UserName;
            Email = create.Email;
        }
        [JsonIgnore]
        public ICollection<UserGame> UserGames { get; set; }
        [NotMapped]
        public IEnumerable<Game> Games => UserGames.Select(x => x.Game);
        [JsonIgnore]
        public ICollection<UserFriend> UserFriends { get; set; }
        [JsonIgnore]
        public ICollection<UserFriend> FriendUsers { get; set; }
        [NotMapped]
        public IEnumerable<User> Friends => UserFriends
            .Select(uf => uf.Friend)
            .Union(FriendUsers.Select(fu => fu.User));

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
