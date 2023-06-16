using System.ComponentModel.DataAnnotations;
using Watchlist.ViewModels.Genre;
using static Watchlist.Common.ValidationConstants.Movie;
namespace Watchlist.ViewModels.Movie
{
    public class MovieFormViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DirectorMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = DirectorMinLength)]
        public string Director { get; set; } = null!;

        [Url]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range((double)RatingMinValue,(double)RatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        public IEnumerable<GenreListViewModel> Genres { get; set; } = new HashSet<GenreListViewModel>();
    }
}


//•	Has Id – a unique integer, Primary Key
//•	Has Title – a string with min length 10 and max length 50 (required)
//•	Has Director – a string with min length 5 and max length 50 (required)
//•	Has ImageUrl – a string (required)
//•	Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
//•	Has GenreId – an integer (required)
//•	Has Genre – a Genre (required)
//•	Has UsersMovies – a collection of type UserMovie
