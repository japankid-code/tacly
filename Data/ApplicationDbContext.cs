using backendv3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace backendv3.Data {
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>> {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<UserGame> UserGame { get; set; }
        public DbSet<UserFriend> UserFriend { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().Property(s => s.CreatedDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<UserFriend>().Property(s => s.CreatedDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Game>().Property(s => s.CreatedDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<UserFriend>()
                .HasOne(uf => uf.Friend)
                .WithMany(u => u.UserFriends)
                .HasForeignKey(uf => uf.FriendId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
