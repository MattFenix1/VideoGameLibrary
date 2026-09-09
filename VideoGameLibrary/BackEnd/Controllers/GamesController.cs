using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return game;
        }
        [HttpPost]
        public async Task<ActionResult<Game>> CreateGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetGame),
                new { id = game.Id },
                game);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(
            int id,
            Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }
            var existingGame = await _context.Games.FindAsync(id);
            if (existingGame == null)
            {
                return NotFound();
            }
            existingGame.Title = game.Title;
            existingGame.Genre = game.Genre;
            existingGame.Developer = game.Developer;
            existingGame.Platform = game.Platform;
            existingGame.ReleaseDate = game.ReleaseDate;
            existingGame.Description = game.Description;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}