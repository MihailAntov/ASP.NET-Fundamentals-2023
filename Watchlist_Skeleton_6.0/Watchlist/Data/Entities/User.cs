using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Entities
{
    public class User : IdentityUser
    {
        public virtual ICollection<UserMovie> UsersMovies { get; set; } = new HashSet<UserMovie>();
    }
}
