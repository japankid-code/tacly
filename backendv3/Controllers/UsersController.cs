using backendv3.Data;
using backendv3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public UsersController(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _dbContext.User.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            return await _dbContext.User.FindAsync(id);
        }

        [HttpPost]
        public async Task Post(CreateUserRequest model)
        {
            var user = new User(model);
            var result = await _userManager.CreateAsync(user, model.Password);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, User model)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
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
    }
}
