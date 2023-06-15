using CarShop.ViewModels.Issue;

namespace CarShop.Services.Contracts
{
    public interface IIssueService
    {
        public Task<CarIssuesViewModel?> GetIssuesByCarIdAsync(string id);
    }
}
