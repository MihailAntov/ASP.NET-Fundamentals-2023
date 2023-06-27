using Homies.Models.Type;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.ValidationConstants.Event;
namespace Homies.Models.Event
{
    public class EventFormViewModel
    {
        [Required]
        [StringLength(NameMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<TypeListViewModel> Types { get; set; } = new List<TypeListViewModel>();

        //TODO validation
    }
}
