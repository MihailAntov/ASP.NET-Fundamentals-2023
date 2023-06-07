using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            //ApplicationUserContacts = new HashSet<ApplicationUserContact>();
            Contacts = new HashSet<Contact>();
        }

        //[Key]
        //public string Id { get; set; } = null!;

        //[MaxLength(20)]
        //[Required]
        //public string UserName { get; set; } = null!;

        //[MaxLength(60)]
        //[Required]
        //public string Email { get; set; } = null!;

        //[Required]
        //public string Password { get; set; } = null!;

        //public virtual ICollection<Contact> Contacts { get; set; }



        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
