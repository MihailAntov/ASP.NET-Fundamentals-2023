using System.ComponentModel.DataAnnotations;

namespace Musaca.ViewModels.Product
{
    using static Musaca.Common.ProductValidationConstants;
    public class ProductFormViewModel
    {
        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        public string Picture { get; set; } = null!;
        [Range(ProductMinPrice,double.MaxValue)]
        public decimal Price { get; set; }

        [RegularExpression(OnlyDigitsRegex)]
        public string Barcode { get; set; } = null!;
    }
}
