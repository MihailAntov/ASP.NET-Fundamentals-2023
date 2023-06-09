using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.ViewModels.Board;

namespace TaskBoardApp.Services.Interfaces
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardViewModel>> All();
        Task<IEnumerable<BoardSelectViewModel>> AllForSelect();
        Task<bool> ExistsId(int id);
    }
}
