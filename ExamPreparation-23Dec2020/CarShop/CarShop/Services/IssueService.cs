using CarShop.Data;
using CarShop.Data.Entities;
using CarShop.Services.Contracts;
using CarShop.ViewModels.Issue;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Services
{
    
    public class IssueService : IIssueService
    {
        private readonly CarShopDbContext context;
        public IssueService(CarShopDbContext context)
        {
            this.context = context;
        }

        public async Task AddIssueAsync(IssueFormViewModel model, string userId)
        {

            Issue issue = new Issue()
            {
                CarId = model.CarId,
                Description = model.Description,
                IsFixed = false
            };
            await context.Issues.AddAsync(issue);
            await context.SaveChangesAsync();
        }

        public async Task DeleteIssueAsync(Guid issueId, Guid carId)
        {
            Issue? issue = await context.Issues
                .Where(i => i.Id == issueId && i.CarId == carId)
                .FirstOrDefaultAsync();

            if(issue != null)
            {
                context.Issues.Remove(issue);
                await context.SaveChangesAsync();
            }
        }

        public async Task FixIssueAsync(Guid issueId, Guid carId)
        {
            Issue? issue = await context.Issues
                .Where(i => i.Id == issueId && i.CarId == carId)
                .FirstOrDefaultAsync();

            if (issue != null)
            {
                issue.IsFixed = true;
                await context.SaveChangesAsync();
            }
        }

        public IssueFormViewModel GetEmptyIssueForm(Guid carId)
        {
            var model = new IssueFormViewModel()
            {
                CarId = carId
            };
            return model;
        }

        public async Task<CarIssuesViewModel?> GetIssuesByCarIdAsync(Guid id)
        {
            var model = await context.Cars
                .Where(c => c.Id == id)
                .Select(c => new CarIssuesViewModel()
                {
                    CarId = c.Id.ToString(),
                    YearAndModel = $"{c.Year} {c.Name}",
                    Issues = c.Issues.Select(i => new IssueListViewModel()
                    {
                        Id = i.Id.ToString(),
                        Description = i.Description,
                        IsItFixed = i.IsFixed ? "Yes" : "Not yet"
                    }).ToArray()
                }).FirstOrDefaultAsync();

            return model;
        }
    }
}
