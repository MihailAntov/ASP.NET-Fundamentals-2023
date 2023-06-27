using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Entities
{
    public class EventParticipant
    {
        [Required]
        [ForeignKey(nameof(Helper))]
        public string HelperId { get; set; } = null!;
        [Required]
        public virtual IdentityUser Helper { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        [Required]
        public Event Event { get; set; } = null!;
    }
}


