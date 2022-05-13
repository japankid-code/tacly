using backendv3.Models;
using System;
using System.Collections.Generic;

namespace backendv3.Data.Repositories {
    public interface IUserRepo {
        void Dispose();
        IEnumerable<User> AllUsers();
        IEnumerable<User> GetAllUsersById(IEnumerable<Guid> userIds);
        User GetUserById(Guid userId);
    }
}