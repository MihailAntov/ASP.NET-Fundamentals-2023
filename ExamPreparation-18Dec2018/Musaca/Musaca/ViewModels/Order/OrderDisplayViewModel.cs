namespace Musaca.ViewModels.Order
{
    public class OrderDisplayViewModel
    {
        public string Name { get; set; } = null!;
        public decimal Total { get; set; }
        public int Quantity { get; set; }
    }
}
