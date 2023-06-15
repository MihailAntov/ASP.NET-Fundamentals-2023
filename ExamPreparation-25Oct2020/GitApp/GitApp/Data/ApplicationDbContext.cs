using GitApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GitApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Commit> Commits { get; set; } = null!;
        public DbSet<Repository> Repositories { get; set; } = null!;
    }
}