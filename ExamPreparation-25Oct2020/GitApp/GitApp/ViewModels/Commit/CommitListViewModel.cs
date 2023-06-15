namespace GitApp.ViewModels.Commit
{
    public class CommitListViewModel
    {
        public string Id { get; set; } = null!;
        public string Repository { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string Description { get; set; } = null!;

    }
}
