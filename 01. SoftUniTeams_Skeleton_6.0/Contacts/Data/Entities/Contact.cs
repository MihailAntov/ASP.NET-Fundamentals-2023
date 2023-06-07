using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Entities
{
    public class Contact
    {
        public Contact()
        {
            //ApplicationUserContacts = new HashSet<ApplicationUserContact>();
            ApplicationUsers = new HashSet<ApplicationUser>();
        }
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; } = null!;

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; } = null!;

        [MaxLength(60)]
        [Required]
        public string Email { get; set; } = null!;

        [MaxLength(13)]
        [Required]
        public string PhoneNumber { get; set; } = null!;


        public string? Address { get; set; }

        [Required]
        public string Website { get; set; } = null!;

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        //public virtual ICollection<ApplicationUserContact> ApplicationUserContacts { get; set; }
    }
}
