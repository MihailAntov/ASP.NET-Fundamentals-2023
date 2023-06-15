namespace CarShop.ViewModels.Issue
{
    public class CarIssuesViewModel
    {
        public string CarId { get; set; } = null!;
        public string YearAndModel { get; set; } = null!;

        public IEnumerable<IssueListViewModel> Issues { get; set; } = new List<IssueListViewModel>();
    }
}
