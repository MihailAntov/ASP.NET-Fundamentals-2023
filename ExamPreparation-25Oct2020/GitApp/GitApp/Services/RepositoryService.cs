using GitApp.Data;
using GitApp.Data.Entities;
using GitApp.Services.Contracts;
using GitApp.ViewModels.Repository;
using Microsoft.EntityFrameworkCore;

namespace GitApp.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext context;
        public RepositoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateRepositoryAsync(RepositoryFormViewModel model, DateTime createdOn, string ownerId)
        {
            Repository repository = new Repository()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                CreatedOn = createdOn,
                OwnerId = ownerId,
                IsPublic = model.RepositoryType == Common.Enums.RepositoryType.Public
            };

            await context.Repositories.AddAsync(repository);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RepositoryListViewModel>> GetAllPublicRepositoriesAsync()
        {
            var repositories = await context.Repositories
                .Where(r=>r.IsPublic)
                .Select(r => new RepositoryListViewModel()
                {
                    Id = r.Id.ToString(),
                    Name = r.Name,
                    CreatedOn = r.CreatedOn.ToString("f"),
                    CommitsCount = r.Commits.Count,
                    Owner = r.Owner != null ? r.Owner.UserName : String.Empty
                }).ToArrayAsync();

            return repositories;
        }
    }
}
