using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendv3.Models {
    public class Game
    {
        public Game() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GameId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        public int Views { get; set; }
        public bool IsComplete { get; set; }
        public bool IsStarted { get; set; }

        // public MoveList MoveList { get; set; }
        public virtual List<UserGame> UserGames { get; set; }

    }

    //public class MoveList
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public Guid MoveListId { get; set; }

    //    public Guid ToGameId;
    //    [ForeignKey("ToGameId")]
    //    public Game Game { get; set; }
    //    public int moveNumber;
    //    public List<Guid> boardState;
    //}

    public class CreateGameRequest
    {
        public Guid userX { get; set; }
        public Guid userO { get; set; }
    }
}
