using Musaca.ViewModels.Product;
using System.ComponentModel.DataAnnotations;
using static Musaca.Common.ProductValidationConstants;
namespace Musaca.ViewModels.Order
{
    public class OrderFormViewModel
    {
        [StringLength(12)]
        [RegularExpression(OnlyDigitsRegex)]
        public string Barcode { get; set; } = null!;
        public int Quantity { get; set; }

        public decimal? Sum { get; set; }
        
        //public string? Cashier { get; set; } = null!;

        public int ProductId { get; set; }


        //public string? CashierId { get; set; }

        
        public IEnumerable<OrderDisplayViewModel>? Orders { get; set; }
    }
}
