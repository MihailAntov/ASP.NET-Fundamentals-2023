using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarShop.Common.ValidationConstants.Car;
namespace CarShop.Data.Entities
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; } 

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0,3000)]
        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; } = null!;


        [Required]
        public string PlateNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;

        [Required]
        public ApplicationUser Owner { get; set; } = null!;

        [InverseProperty(nameof(Car))]
        public virtual ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();
    }
}
