using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Entities;
using Watchlist.Services.Contracts;
using Watchlist.ViewModels.Genre;
using Watchlist.ViewModels.Movie;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;
        public MovieService(WatchlistDbContext context)
        {
            this.context = context;
        }

        public async Task AddMovieAsync(MovieFormViewModel model)
        {
            Movie movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                Rating = model.Rating,
                ImageUrl = model.ImageUrl,
                GenreId = model.GenreId,
            };

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }

       

        public async Task<IEnumerable<GenreListViewModel>> GetAllGenresAsync()
        {
            var genres = await context.Genres
                .Select(g => new GenreListViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToArrayAsync();

            return genres;
        }

        public async Task<IEnumerable<MovieListViewModel>> GetAllMoviesAsync()
        {
            var movies = await context.Movies
                .Select(m => new MovieListViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m.Genre.Name
                }).ToArrayAsync();

            return movies;
        }

        public async Task<IEnumerable<MovieListViewModel>> GetWatchedMoviesAsync(string id)
        {
            var movies = await context.UsersMovies
                .Where(um=> um.UserId == id)
                .Select(m => new MovieListViewModel()
                {
                    Id = m.Movie.Id,
                    Title = m.Movie.Title,
                    Director = m.Movie.Director,
                    ImageUrl = m.Movie.ImageUrl,
                    Rating = m.Movie.Rating,
                    Genre = m.Movie.Genre.Name
                }).ToArrayAsync();

            return movies;
        }

        public async Task AddToCollectionAsync(int movieId, string userId)
        {
            var exists = await GetMovieFromUsersCollection(movieId, userId);
            if (exists == null)
            {
                UserMovie userMovie = new UserMovie()
                {
                    UserId = userId,
                    MovieId = movieId
                };

                await context.UsersMovies.AddAsync(userMovie);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromCollectionAsync(int movieId, string userId)
        {
            var exists = await GetMovieFromUsersCollection(movieId, userId);

            if(exists != null)
            {
                context.UsersMovies.Remove(exists);
                await context.SaveChangesAsync();
            }
        }

        private async Task<UserMovie?> GetMovieFromUsersCollection(int movieId, string userId)
        {
            var result = await context.UsersMovies
                .Where(um => um.UserId == userId && um.MovieId == movieId)
                .FirstOrDefaultAsync();

            return result;
                
        }
    }
}
