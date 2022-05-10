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
        public UserGame(Guid gameId, Guid userId)
        {
            GameId = gameId;
            UserId = userId;
        }

        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }

}
