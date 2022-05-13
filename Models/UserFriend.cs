using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendv3.Models {
    public class UserFriend {
        public UserFriend() { }
        public UserFriend(CreateUserFriendRequest create) {
            UserId = create.UserId;
            FriendId = create.FriendId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserFriendId { get; set; }

        public Guid UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid FriendId { get; set; }
        [ForeignKey(nameof(FriendId))]
        public virtual User Friend { get; set; }
    }

    public class CreateUserFriendRequest {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}
