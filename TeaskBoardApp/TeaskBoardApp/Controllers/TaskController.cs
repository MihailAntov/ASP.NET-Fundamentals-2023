using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.ViewModels.Board;
using TaskBoardApp.ViewModels.Task;


namespace TeaskBoardApp.Controllers
{
    public class TaskController : Controller
    {
        IBoardService boardService;
        ITaskService taskService;
        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this.boardService = boardService;
            this.taskService = taskService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel model = new TaskFormModel()
            {
                Boards = await boardService.AllForSelect()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await boardService.ExistsId(model.BoardId))
            {
                ModelState.AddModelError("Board", "No such category exists.");
                return View(model);
            }

            model.Boards = await boardService.AllForSelect();



            string currentId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await taskService.Create(currentId, model);

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await taskService.Details(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            TaskFormModel model = await taskService.GetForEdit(id);
            model.Boards = await boardService.AllForSelect();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel model)
        {
            
            await taskService.Edit(id, model);
            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            TaskViewModel model = await taskService.GetForDelete(id);
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, TaskViewModel model)
        {
            await taskService.Delete(id, model);
            return RedirectToAction("All", "Board");

        }
    }
}
