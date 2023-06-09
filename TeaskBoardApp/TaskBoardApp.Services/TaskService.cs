using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.ViewModels.Board;
using TaskBoardApp.ViewModels.Task;
using TeaskBoardApp.Data;

namespace TaskBoardApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext context;
        private readonly IBoardService boardService;
        public TaskService(ApplicationDbContext context, IBoardService boardService)
        {
            this.context = context;
            this.boardService = boardService;
        }
        public async Task Create(string ownerId, TaskFormModel model)
        {


            Data.Models.Entities.Task task = new Data.Models.Entities.Task()
            {
                Title = model.Title,
                Description = model.Description,
                OwnerId = ownerId,
                BoardId = model.BoardId

            };

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
        }

        public async Task<TaskViewModel> GetForDelete(int id)
        {
            TaskViewModel model = await context.Tasks
                .Select(t => new TaskViewModel()
                {
                    Id = id,
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.Owner.UserName
                })
                .FirstAsync(t => t.Id == id);

            return model;
        }

        public async Task Delete(int id, TaskViewModel model)
        {
            var task = await context.Tasks.FirstAsync(t => t.Id == model.Id);
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }

        public async Task<TaskDetailsViewModel> Details(int id)
        {

            TaskDetailsViewModel model = await context.Tasks
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.Owner.UserName,
                    Board = t.Board.Name,
                    CreatedOn = t.CreatedOn.ToString("f")
                })
                .FirstAsync(t => t.Id == id);


            return model;
                
        }

        public async Task<TaskFormModel> GetForEdit(int id)
        {
            //var boards = await boardService.AllForSelect();
            //TaskFormModel model = await context.Tasks
            //    .Where(t => t.Id == id)
            //    .Select(t => new TaskFormModel()
            //    {
            //        Title = t.Title,
            //        Description = t.Description,
            //        BoardId = t.BoardId,
            //        Boards = boards,
            //    })
            //    .FirstAsync();

            TaskFormModel model = await context.Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskFormModel()
                {
                    
                    Title = t.Title,
                    Description = t.Description,
                    BoardId = t.Board.Id,
                })
                .FirstAsync();

            return model;
                
        }

        public async Task Edit(int id, TaskFormModel model)
        {
            TaskBoardApp.Data.Models.Entities.Task task = await context.Tasks.FirstAsync(t=>t.Id == id);
            task.BoardId = model.BoardId;
            task.Title = model.Title;
            task.Description = model.Description;

            await context.SaveChangesAsync();

        }
    }
}
