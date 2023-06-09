using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.ViewModels.Board;

namespace TeaskBoardApp.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;
        public BoardController(IBoardService boardService)
        {
            this.boardService = boardService;
        }
        public async Task<IActionResult> All()
        {
            var allBoards = await boardService.All();
            return View(allBoards);
        }

        public async Task<IEnumerable<BoardSelectViewModel>> AllForSelect()
        {
            var boards = await boardService.AllForSelect();
            return boards;
        }

        
    }
}
