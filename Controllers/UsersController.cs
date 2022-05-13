using backendv3.Data;
using backendv3.Data.Repositories;
using backendv3.Models;
using backendv3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendv3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IUserRepo _userRepo;
        private readonly IUserService _userService;

        public UsersController(ApplicationDbContext dbContext, UserManager<User> userManager, IConfiguration configuration, IUserRepo userRepo, IUserService userService) {
            _userManager = userManager;
            _dbContext = dbContext;
            _configuration = configuration;
            _userRepo = userRepo;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers() {
            try {
                return Ok(_userService.GetAllUsers());
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId:Guid}")]
        public ActionResult<User> Get(Guid userId) {
            try {
                return _userService.GetUserById(userId);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRequest model) {
            try {
                return Ok(await _userService.CreateAndLoginUserAsync(model));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUserAsync(User user) {
            try {
                await _userService.UpdateUserAsync(user);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteUser(Guid id) {
            var user = await _dbContext.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _dbContext.User.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpPost("{id:Guid}/{friendId:Guid}")]
        public async Task<ActionResult> Put(Guid id, Guid friendId, CreateUserFriendRequest model) {
            var alreadyExists = await _dbContext.UserFriend.AnyAsync(f => f.FriendId == friendId);
            if (alreadyExists) return Ok("friend already added");

            var userExists = await _dbContext.User.AnyAsync(u => u.Id == id);
            if (!userExists) return NotFound();

            var friendExists = await _dbContext.User.AnyAsync(f => f.Id == friendId);
            if (!friendExists) return NotFound();

            model.UserId = id;
            model.FriendId = friendId;
            var friend = new UserFriend(model);

            var addFriend = await _dbContext.UserFriend.AddAsync(friend);

            await _dbContext.SaveChangesAsync();

            return Ok(addFriend);
        }

        [Authorize]
        [HttpDelete("{id:Guid}/{friendId:Guid}")]
        public async Task<ActionResult> DeleteFriend(Guid id, Guid friendId) {

            var userExists = await _dbContext.User.AnyAsync(u => u.Id == id);
            if (!userExists) return NotFound();

            var friendExists = await _dbContext.User.AnyAsync(f => f.Id == friendId);
            if (!friendExists) return NotFound();

            var friend = await _dbContext.UserFriend.FindAsync(friendId);
            if (friend == null) return NotFound();
            _dbContext.UserFriend.Remove(friend);
            await _dbContext.SaveChangesAsync();
            return Ok(friend);
        }
    }
}
