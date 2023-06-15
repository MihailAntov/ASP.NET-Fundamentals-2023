using GitApp.ViewModels.Commit;

namespace GitApp.Services.Contracts
{
    public interface ICommitService
    {
        public CommitFormViewModel GetCommitFromId(string id);
        public Task CreateCommitAsync(CommitFormViewModel model, DateTime createdOn, string creatorId);

        public Task<IEnumerable<CommitListViewModel>> GetAllCommitsAsync(string id);

        public Task DeleteCommitAsync(string id, string userId);

    }
}
