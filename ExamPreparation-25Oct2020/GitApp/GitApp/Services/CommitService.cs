using GitApp.Data;
using GitApp.Data.Entities;
using GitApp.Services.Contracts;
using GitApp.ViewModels.Commit;
using Microsoft.EntityFrameworkCore;

namespace GitApp.Services
{
    public class CommitService : ICommitService
    {
        private readonly ApplicationDbContext context;
        public CommitService(ApplicationDbContext context)
        {
            this.context = context;
        }

        

        public async Task CreateCommitAsync(CommitFormViewModel model, DateTime createdOn, string creatorId)
        {
            Commit commit = new Commit()
            {
                Id = Guid.NewGuid().ToString(),
                Description = model.Description,
                CreatedOn = createdOn,
                CreatorId = creatorId,
                RepositoryId = model.RepositoryId
            };
            await context.Commits.AddAsync(commit);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCommitAsync(string id, string userId)
        {
            Commit? commitToDelete = await context.Commits.FirstOrDefaultAsync(c => c.Id == id);
            if(commitToDelete != null)
            {
                //not sure if "owner" refers to commit creator or repository owner. 
                //if(commitToDelete.Repository.OwnerId == userId)
                //is the alternative check
                if(commitToDelete.CreatorId == userId)
                {
                    context.Commits.Remove(commitToDelete);
                    await context.SaveChangesAsync();
                }
            }

        }

        

        public async Task<IEnumerable<CommitListViewModel>> GetAllCommitsAsync(string id)
        {
            var commits = await context.Commits
                .Where(c => c.CreatorId == id)
                .Select(c => new CommitListViewModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToString("f"),
                    Repository = c.Repository != null ? c.Repository.Name : String.Empty
                }).ToArrayAsync();

            return commits;
        }

        public CommitFormViewModel GetCommitFromId(string id)
        {
            var model = new CommitFormViewModel()
            {
                RepositoryId = id,
            };
            return model;
        }
    }
}
