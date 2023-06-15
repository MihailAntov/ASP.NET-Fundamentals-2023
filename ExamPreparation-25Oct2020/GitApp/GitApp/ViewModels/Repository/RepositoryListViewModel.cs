namespace GitApp.ViewModels.Repository
{
    public class RepositoryListViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string CreatedOn { get; set; } = null!;
        public int CommitsCount { get; set; }
        public string Owner { get; set; } = null!;
    }
}
