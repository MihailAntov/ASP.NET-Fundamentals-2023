using Microsoft.AspNetCore.Identity;
using Musaca.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musaca.Data.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Required]
        public Product Product { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(Cashier))]
        public string CashierId { get; set; } = null!;

        [Required]
        public IdentityUser Cashier { get; set; } = null!;
    }
}
