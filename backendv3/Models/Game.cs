using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backendv3.Models
{
    public class Game
    {
        public Game() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string GameId { get; set; }
        public int Views { get; set; }
        public bool IsComplete { get; set; }
        public bool IsStarted { get; set; }

        // public MoveList MoveList { get; set; }

        public ICollection<UserGame> UserGames { get; set; }

    }

    //public class MoveList
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public string MoveListId { get; set; }

    //    public string ToGameId;
    //    [ForeignKey("ToGameId")]
    //    public Game Game { get; set; }
    //    public int moveNumber;
    //    public List<string> boardState;
    //}

}
