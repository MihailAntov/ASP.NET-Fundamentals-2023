using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            
            Contacts = new HashSet<Contact>();
        }

        



        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
