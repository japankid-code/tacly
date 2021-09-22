using backendv3.Data;
using backendv3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace backendv3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // inject dependencies...
        private readonly ApplicationDbContext _dbContext;
        public GamesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // add routing methods
        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()
        {
            return await _dbContext.Game.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(string id)
        {
            return await _dbContext.Game.FindAsync(id);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(CreateGameRequest request)
        {
            var game = new Game();
            await _dbContext.Game.AddAsync(game);

            var playerX = new UserGame(game.GameId, request.userX);
            await _dbContext.UserGame.AddAsync(playerX);
            var existsX = await _dbContext.User.FirstOrDefaultAsync(f => f.Id == request.userX);
            existsX.UserGames.Add(playerX);

            var playerO = new UserGame(game.GameId, request.userO);
            await _dbContext.UserGame.AddAsync(playerO);
            var existsO = await _dbContext.User.FirstOrDefaultAsync(f => f.Id == request.userO);
            existsO.UserGames.Add(playerO);

            if (existsX == null || existsO == null)
            {
                return NotFound();
            }

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, Game model)
        {
            var exists = await _dbContext.Game.AnyAsync(g => g.GameId == id);
            if (!exists)
            {
                return NotFound();
            }
            _dbContext.Game.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var game = await _dbContext.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            _dbContext.Game.Remove(game);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
