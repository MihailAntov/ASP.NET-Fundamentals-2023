using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Services.Contracts;
using Watchlist.ViewModels.Movie;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> All()
        {
            var model =  await _movieService.GetAllMoviesAsync();
            return View(model);
        }

        public async Task<IActionResult> Watched()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _movieService.GetWatchedMoviesAsync(userId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var genres = await _movieService.GetAllGenresAsync();
            MovieFormViewModel model = new MovieFormViewModel() { Genres = genres };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _movieService.AddMovieAsync(model);

            return RedirectToAction("All", "Movies");
        }

        public async Task<IActionResult> AddToCollection(int movieId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _movieService.AddToCollectionAsync(movieId, userId);
            return RedirectToAction("All", "Movies");
        }

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _movieService.RemoveFromCollectionAsync(movieId, userId);
            return RedirectToAction("Watched", "Movies");
        }


    }
}
