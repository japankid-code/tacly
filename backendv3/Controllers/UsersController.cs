using backendv3.Data;
using backendv3.Models;
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
        private readonly ApplicationDbContext _dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _dbContext.User.ToListAsync();
            // return Ok(new { data = "hello world" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            return await _dbContext.User.FindAsync(id);
        }

        [HttpPost]
        public async Task Post(User model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
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
    }
}
