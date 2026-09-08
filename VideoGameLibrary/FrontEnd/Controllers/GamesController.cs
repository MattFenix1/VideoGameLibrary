using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using VideoGameLibrary.FrontEnd.Models;
namespace FrontEnd.Controllers
{
    public class GamesController : Controller
    {
        private readonly HttpClient _httpClient;
        public GamesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("GameApi");
        }
        public async Task<IActionResult> Index()
        {
            var games = await _httpClient.GetFromJsonAsync<List<Game>>(
                "api/games");

            return View(games ?? new List<Game>());
        }
        public async Task<IActionResult> Details(int id)
        {
            var game = await _httpClient.GetFromJsonAsync<Game>(
                $"api/games/{id}");

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
            if (!ModelState.IsValid)
            {
                return View(game);
            }
            var response = await _httpClient.PostAsJsonAsync(
                "api/games",
                game);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(
                "",
                "Unable to create the game.");

            return View(game);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _httpClient.GetFromJsonAsync<Game>(
                $"api/games/{id}");
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
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(game);
            }
            var response = await _httpClient.PutAsJsonAsync(
                $"api/games/{id}",
                game);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(
                "",
                "Unable to update the game.");

            return View(game);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _httpClient.GetFromJsonAsync<Game>(
                $"api/games/{id}");
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
            var response = await _httpClient.DeleteAsync(
                $"api/games/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("Unable to delete the game.");
        }
    }
}