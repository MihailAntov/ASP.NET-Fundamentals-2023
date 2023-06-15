using GitApp.Services.Contracts;
using GitApp.ViewModels.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GitApp.Controllers
{
    [Authorize]
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;
        public RepositoriesController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }
        public async Task<IActionResult> All()
        {
            var model = await repositoryService.GetAllPublicRepositoriesAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RepositoryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("All", "Repositories");
            }

            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            DateTime createdOn = DateTime.UtcNow;
            await repositoryService.CreateRepositoryAsync(model, createdOn, userId);
            return RedirectToAction("All", "Repositories");
        }
    }
}
