using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendv3.Models {
    public class UserGame {
        public UserGame() { }
        public UserGame(Guid gameId, Guid userId) {
            GameId = gameId;
            UserId = userId;
        }

        public Guid UserGameId { get; set; }
        public Guid GameId { get; set; }
        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }

}
