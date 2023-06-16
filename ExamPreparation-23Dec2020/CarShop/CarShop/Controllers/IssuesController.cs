using CarShop.Services.Contracts;
using CarShop.ViewModels.Issue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        public async Task<IActionResult> CarIssues(Guid carId)
        {
            var model = await issueService.GetIssuesByCarIdAsync(carId);
            if(model == null)
            {
                return RedirectToAction("All", "Cars");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Add(Guid carId)
        {
            var model = issueService.GetEmptyIssueForm(carId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(IssueFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await issueService.AddIssueAsync(model, userId);
            return RedirectToAction("CarIssues", new { carId = model.CarId });
        }

        public async Task<IActionResult> Delete(Guid issueId, Guid carId)
        {
            await issueService.DeleteIssueAsync(issueId, carId);
            return RedirectToAction("CarIssues",new {carId = carId });
        }
        [Authorize(Roles = "Mechanic")]
        public async Task<IActionResult> Fix(Guid issueId, Guid carId)
        {
            await issueService.FixIssueAsync(issueId, carId);
            return RedirectToAction("CarIssues", new { carId = carId });
        }


    }
}
