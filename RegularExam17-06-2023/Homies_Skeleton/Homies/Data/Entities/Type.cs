using System.ComponentModel.DataAnnotations;
using static Homies.Common.ValidationConstants.Type;
namespace Homies.Data.Entities
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}


//•	Has Id – a unique integer, Primary Key
//•	Has Name – a string with min length 5 and max length 15 (required)
//•	Has Events – a collection of type Event
