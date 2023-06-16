using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.ValidationConstants.Genre;
namespace Watchlist.Data.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;


        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
