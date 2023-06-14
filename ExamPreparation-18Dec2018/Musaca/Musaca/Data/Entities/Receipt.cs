using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Musaca.Data.Entities
{
    public class Receipt
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; }
        public ICollection<Order> Orders { get; set; } = null!;

        [Required]
        public string CashierId { get; set; } = null!;

        [Required]
        public IdentityUser Cashier { get; set; } = null!;
    }
}
