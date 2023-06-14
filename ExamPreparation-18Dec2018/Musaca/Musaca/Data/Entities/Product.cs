using System.ComponentModel.DataAnnotations;

namespace Musaca.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        
        public decimal Price { get; set; }

        [StringLength(12)]
        [Required]
        public string Barcode { get; set; } = null!;

        [Required]
        public string Picture { get; set; } = null!;
    }
}
