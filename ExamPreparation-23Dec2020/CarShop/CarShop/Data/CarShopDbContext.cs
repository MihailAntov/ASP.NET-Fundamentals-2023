using CarShop.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Data
{
    public class CarShopDbContext : IdentityDbContext
    {
        public CarShopDbContext(DbContextOptions<CarShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> CarShopUsers { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Issue> Issues { get; set; } = null!;
    }
}