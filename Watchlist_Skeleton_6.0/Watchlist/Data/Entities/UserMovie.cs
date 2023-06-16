using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.Entities
{
    public class UserMovie
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}


//•	UserId – a string, Primary Key, foreign key (required)
//•	User – User
//•	MovieId – an integer, Primary Key, foreign key (required)
//•	Movie – Movie
