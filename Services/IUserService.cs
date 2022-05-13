using backendv3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backendv3.Services {
    public interface IUserService {
        Task<object> CreateAndLoginUserAsync(CreateUserRequest model);
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid userId);
        Task UpdateUserAsync(User user);
        Task<object> LoginUserAsync(LoginUserRequest model);
    }
}