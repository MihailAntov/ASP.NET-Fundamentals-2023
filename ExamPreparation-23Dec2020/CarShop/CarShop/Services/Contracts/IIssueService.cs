using CarShop.ViewModels.Issue;

namespace CarShop.Services.Contracts
{
    public interface IIssueService
    {
        public Task<CarIssuesViewModel?> GetIssuesByCarIdAsync(Guid id);
        public IssueFormViewModel GetEmptyIssueForm(Guid carId);
        public Task AddIssueAsync(IssueFormViewModel model, string userId);

        public Task DeleteIssueAsync(Guid issueId, Guid carId);

        public Task FixIssueAsync(Guid issueId, Guid carId);
    }
}
