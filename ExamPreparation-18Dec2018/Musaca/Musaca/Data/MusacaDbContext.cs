using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musaca.Data.Entities;

namespace Musaca.Data
{
    public class MusacaDbContext : IdentityDbContext
    {
        public MusacaDbContext(DbContextOptions<MusacaDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Receipt> Receipts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property("Price")
                .HasPrecision(18, 2);


            
            base.OnModelCreating(builder);
        }
    }
}