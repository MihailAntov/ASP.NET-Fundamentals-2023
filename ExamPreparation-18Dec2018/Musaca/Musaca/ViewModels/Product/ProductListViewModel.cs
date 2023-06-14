namespace Musaca.ViewModels.Product
{
    public class ProductListViewModel
    {
        public string Barcode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Picture { get; set; } = null!;
    }
}
