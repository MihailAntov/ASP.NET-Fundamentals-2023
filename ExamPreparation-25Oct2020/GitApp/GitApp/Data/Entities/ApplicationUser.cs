using Microsoft.AspNetCore.Identity;

namespace GitApp.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Repository> Repositories { get; set; } = new HashSet<Repository>();
        public virtual ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
