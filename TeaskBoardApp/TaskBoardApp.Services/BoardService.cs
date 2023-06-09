
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.ViewModels.Board;
using TaskBoardApp.ViewModels.Task;
using TeaskBoardApp.Data;

namespace TaskBoardApp.Services
{
    public class BoardService : IBoardService
    {
        private readonly ApplicationDbContext context;
        public BoardService(ApplicationDbContext context)
        {
            this.context = context;
        }
    
        public async Task<IEnumerable<BoardViewModel>> All()
        {
            var boards = await context.Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Description = t.Description,
                        Owner = t.Owner.UserName,
                        Title = t.Title
                    })
                }).ToArrayAsync();

            return boards;
        }

        public async Task<IEnumerable<BoardSelectViewModel>> AllForSelect()
        {
            var boards = await context.Boards
                .Select(b=> new BoardSelectViewModel()
                {
                    Id =b.Id,
                    Name=b.Name,
                })
                .ToArrayAsync();

            return boards;
        }

        public async Task<bool> ExistsId(int id)
        {
            bool result = await context.Boards.AnyAsync(b => b.Id == id);
            return result;
        }
    }
}
