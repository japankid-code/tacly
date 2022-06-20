using backendv3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace backendv3.Data.Repositories {
    public interface IUserRepo : IDbSet<User> {
        void Save();
        void Dispose();
        IEnumerable<User> AllUsers();
        IEnumerable<User> GetAllUsersById(IEnumerable<Guid> userIds);
        User GetUserById(Guid userId);
    }
}