using Forum.Services.Interfaces;
using Forum.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;

namespace Forum.App.Controllers
{
    public class PostController : Controller
    {

        private IPostService postService;
        public PostController(IPostService service)
        {
            this.postService = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<PostListViewModel> model = await postService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await postService.CreateAsync(model);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            PostFormModel model = await postService.GetForEditOrDeleteById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel model)
        {
            await postService.EditAsync(id, model);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            PostFormModel model = await postService.GetForEditOrDeleteById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, PostFormModel model)
        {
            await postService.DeleteAsync(id);
            return RedirectToAction("All");
        }




    }
}
