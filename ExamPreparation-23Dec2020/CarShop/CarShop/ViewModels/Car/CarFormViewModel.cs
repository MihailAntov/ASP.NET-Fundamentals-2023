using System.ComponentModel.DataAnnotations;
using static CarShop.Common.ValidationConstants.Car;
namespace CarShop.ViewModels.Car
{
    public class CarFormViewModel
    {
        [Required]
        [MinLength(ModelMinLength)]
        [MaxLength(ModelMaxLength)]
        public string Name { get; set; } = null!;

        [Range(0,3000)]
        [Required]
        public int Year { get; set; }

        [Url]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [RegularExpression(PlateRegex)]
        [Required]
        public string PlateNumber { get; set; } = null!;

    }
}
