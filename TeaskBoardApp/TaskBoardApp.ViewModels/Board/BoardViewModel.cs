using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.ViewModels.Task;

namespace TaskBoardApp.ViewModels.Board
{
    public class BoardViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public IEnumerable<TaskViewModel> Tasks { get; set; } = null!;
    }
}
