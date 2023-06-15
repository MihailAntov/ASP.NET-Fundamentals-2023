using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Data.Entities
{
    public class Issue
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public bool IsFixed { get; set; }

        [ForeignKey(nameof(Car))]
        [Required]
        public Guid CarId { get; set; } 

        [Required]
        public Car Car { get; set; } = null!;
    }
}
