using System.ComponentModel.DataAnnotations;

namespace Contacts.Models.Contacts
{
    public class ContactFormViewModel
    {
        [MinLength(2), MaxLength(50)]
        [Required]
        public string FirstName { get; set; } = null!;

        [MinLength(5), MaxLength(50)]
        [Required]
        public string LastName { get; set; } = null!;

        [MinLength(10), MaxLength(13)]
        [Required]
        [RegularExpression(@"(\+359|0)([-\s]?)\d{3}\2\d{2}\2\d{2}\2\d{2}")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [RegularExpression(@"www\.[\dA-Za-z\-]+\.bg")]
        public string Website { get; set; } = null!;

        [Required]
        [MinLength(10), MaxLength(60)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
    }
}
