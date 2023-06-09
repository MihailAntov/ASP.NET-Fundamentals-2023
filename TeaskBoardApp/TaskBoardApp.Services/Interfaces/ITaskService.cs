using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.ViewModels.Board;
using TaskBoardApp.ViewModels.Task;

namespace TaskBoardApp.Services.Interfaces
{
    public interface ITaskService
    {
        Task Create(string ownerId, TaskFormModel model);
        Task<TaskDetailsViewModel> Details(int id);

        Task<TaskFormModel> GetForEdit(int id);
        Task Edit(int id, TaskFormModel model);
        Task<TaskViewModel> GetForDelete(int id);
        Task Delete(int id, TaskViewModel model);

    }
}
