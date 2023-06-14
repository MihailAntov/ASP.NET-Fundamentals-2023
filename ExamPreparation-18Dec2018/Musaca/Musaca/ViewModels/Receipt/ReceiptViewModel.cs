using Musaca.ViewModels.Order;

namespace Musaca.ViewModels.Receipt
{
    public class ReceiptViewModel
    {
        public string Id { get; set; } = null!;
        public decimal Total { get; set; }
        public string IssuedOn { get; set; } = null!;
        public string Cashier { get; set; } = null!;
        public string CashierId { get; set; } = null!;

        public IEnumerable<OrderDisplayViewModel> Orders { get; set; } = null!;
    }
}
