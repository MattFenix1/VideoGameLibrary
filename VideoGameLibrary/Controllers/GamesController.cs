using VideoGameLibrary.Data;
using VideoGameLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameLibrary.Models;
namespace VideoGameLibrary.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameDbContext _context;
        public GamesController(GameDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var games = await _context.Games.ToListAsync();

            return View(games);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var game = await _context.Games
                .FirstOrDefaultAsync(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var game = await _context.Games
                .FirstOrDefaultAsync(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        private bool GameExists(int id)
        {
            return _context.Games.Any(g => g.Id == id);
        }
    }
}