using CarShop.Data;
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

        public async Task<CarIssuesViewModel?> GetIssuesByCarIdAsync(string id)
        {
            var model = await context.Cars
                .Where(c => c.Id.ToString() == id)
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
