using backendv3.Controllers;
using backendv3.Data.Repositories;
using backendv3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace backendv3.Services {
    public class UserService : IUserService {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUserRepo _userRepo;

        public UserService(UserManager<User> userManager, IConfiguration configuration, IUserRepo userRepo) {
            _userManager = userManager;
            _configuration = configuration;
            _userRepo = userRepo;
        }

        public async Task<object> CreateAndLoginUserAsync(CreateUserRequest model) {
            var user = new User(model);
            await _userManager.CreateAsync(user, model.Password);
            _userRepo.Save();
            LoginUserRequest login = model;
            return await LoginUserAsync(login);
        }

        public IEnumerable<User> GetAllUsers() {
            return _userRepo.AllUsers().ToList();
        }

        public User GetUserById(Guid userId) {
            return _userRepo.GetUserById(userId);
        }

        public async Task<object> LoginUserAsync(LoginUserRequest model) {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password)) {
                var authClaims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(48),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };
            } else throw new UnauthorizedAccessException();
        }

        public async Task UpdateUserAsync(User user) {
            await _userManager.UpdateAsync(user);
        }


    }
}
