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

        // add foreign keys for game
        public string GameId { get; set; }
        public Game Game { get; set; }

        // add foreign keys for players and winner
        public string UserId { get; set; }

        public User User { get; set; }


    }
}
