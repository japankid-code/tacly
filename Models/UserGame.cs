using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace backendv3.Models
{
    public class UserGame
    {
        public UserGame() { }
        public UserGame(string gameId, string userId)
        {
            GameId = gameId;
            UserId = userId;
        }

        public string GameId { get; set; }
        public Game Game { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }

}
