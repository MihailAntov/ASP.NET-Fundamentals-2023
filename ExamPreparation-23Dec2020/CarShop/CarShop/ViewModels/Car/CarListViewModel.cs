namespace CarShop.ViewModels.Car
{
    public class CarListViewModel
    {
        public string Id { get; set; } = null!;
        public string ModelAndYear { get; set; } = null!;
        public string PlateNumber { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        public int RemainingIssues { get; set; } 
        public int FixedIssues { get; set; } 
    }
}
