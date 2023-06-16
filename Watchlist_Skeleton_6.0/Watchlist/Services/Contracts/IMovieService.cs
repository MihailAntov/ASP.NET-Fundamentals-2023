using Watchlist.ViewModels.Genre;
using Watchlist.ViewModels.Movie;

namespace Watchlist.Services.Contracts
{
    public interface IMovieService
    {
        public Task<IEnumerable<MovieListViewModel>> GetAllMoviesAsync();
        public Task<IEnumerable<MovieListViewModel>> GetWatchedMoviesAsync(string id);
        public Task<IEnumerable<GenreListViewModel>> GetAllGenresAsync();

        public Task AddMovieAsync(MovieFormViewModel model);

        public Task AddToCollectionAsync(int movieId, string userId);
        public Task RemoveFromCollectionAsync(int movieId, string userId);
    }
}
