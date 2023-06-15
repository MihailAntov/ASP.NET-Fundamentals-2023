using Microsoft.AspNetCore.Identity;

namespace CarShop.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        
        public bool IsMechanic { get; set; }
    }
}
