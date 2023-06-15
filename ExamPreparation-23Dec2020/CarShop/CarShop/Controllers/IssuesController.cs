using CarShop.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;
        public IssuesController(IIssueService issueService)
        {
            this.issueService = issueService;
        }

        public async Task<IActionResult> CarIssues(string carId)
        {
            var model = await issueService.GetIssuesByCarIdAsync(carId);
            if(model == null)
            {
                return RedirectToAction("All", "Cars");
            }
            return View(model);
        }
    }
}
