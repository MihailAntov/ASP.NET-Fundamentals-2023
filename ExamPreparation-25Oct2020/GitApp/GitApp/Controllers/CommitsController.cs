using GitApp.Services.Contracts;
using GitApp.ViewModels.Commit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GitApp.Controllers
{
    [Authorize]
    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;
        public CommitsController(ICommitService commitService)
        {
            this.commitService = commitService;
        }

        [HttpGet]
        public IActionResult Create(string id)
        {
            var model = commitService.GetCommitFromId(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommitFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            DateTime createdOn = DateTime.UtcNow;

            await commitService.CreateCommitAsync(model,createdOn, userId);

            return RedirectToAction("All", "Repositories");
        }

        public async Task<IActionResult> All()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await commitService.GetAllCommitsAsync(userId);
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await commitService.DeleteCommitAsync(id, userId);

            return RedirectToAction("All");
        }
    }
}
