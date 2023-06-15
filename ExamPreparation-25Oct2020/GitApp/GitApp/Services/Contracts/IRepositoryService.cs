using GitApp.ViewModels.Repository;

namespace GitApp.Services.Contracts
{
    public interface IRepositoryService
    {
        public Task<IEnumerable<RepositoryListViewModel>> GetAllPublicRepositoriesAsync();
        public Task CreateRepositoryAsync(RepositoryFormViewModel model,DateTime createdOn, string ownerId);
    }
}
