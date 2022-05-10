using backendv3.Data;
using backendv3.Models;
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

        public UsersController(ApplicationDbContext dbContext, UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _dbContext.User
                .Include(u => u.UserGames)
                .ThenInclude(ug => ug.Game)
                .Include(u => u.UserFriends)
                .ThenInclude(uf => uf.Friend)
                .Include(u => u.FriendUsers)
                .ThenInclude(uf => uf.User)
                .ToListAsync();
        }

        [HttpGet("id/{id:Guid}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            return await _dbContext.User
                .Include(u => u.UserGames)
                .ThenInclude(ug => ug.Game)
                .Include(u => u.UserFriends)
                .ThenInclude(uf => uf.Friend)
                .Include(u => u.FriendUsers)
                .ThenInclude(uf => uf.User)
                .FirstOrDefaultAsync(u => u.Id == id); ;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<User>> Get(string username)
        {
            return await _dbContext.User
                .Include(u => u.UserGames)
                .ThenInclude(ug => ug.Game)
                .Include(u => u.UserFriends)
                .ThenInclude(uf => uf.Friend)
                .Include(u => u.FriendUsers)
                .ThenInclude(uf => uf.User)
                .FirstOrDefaultAsync(u => u.UserName == username); ;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRequest model)
        {
            var user = new User(model);
            await _userManager.CreateAsync(user, model.Password);
            LoginUserRequest login = model;
            var request = new UserAuthController(_userManager, _configuration);
            return await request.Login(login);
        }
        [Authorize]
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Put(Guid id, User model)
        {
            var exists = await _dbContext.User.AnyAsync(f => f.Id == id);
            if (!exists)
            {
                return NotFound();
            }

            _dbContext.User.Update(model);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [Authorize]
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
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
        public async Task<ActionResult> Put(Guid id, Guid friendId, CreateUserFriendRequest model)
        {
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
        public async Task<ActionResult> DeleteFriend(Guid id, Guid friendId)
        {

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
