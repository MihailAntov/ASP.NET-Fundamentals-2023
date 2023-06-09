using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Task = TaskBoardApp.Data.Models.Entities.Task;
using TaskBoardApp.Data.Models.Entities;
using TaskBoardApp.Data.Configuration;

namespace TeaskBoardApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BoardEntityConfiguration());
            builder.ApplyConfiguration(new TaskEntityConfiguration());
        }

        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<Board> Boards { get; set; } = null!;
    }
}