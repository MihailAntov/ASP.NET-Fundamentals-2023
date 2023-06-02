using Forum.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostListViewModel>> GetAllAsync ();
        Task CreateAsync(PostFormModel model);

        Task<PostFormModel> GetForEditOrDeleteById(int id);
        Task EditAsync(int id, PostFormModel model);

        Task DeleteAsync(int id);   
    }
}
