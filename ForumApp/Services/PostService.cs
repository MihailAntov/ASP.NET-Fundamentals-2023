using Forum.Data;
using Forum.Data.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Services
{
    public class PostService : IPostService
    {
        ApplicationDbContext context;
        IHttpContextAccessor httpContextAccessor;
        public PostService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateAsync(PostFormModel model)
        {
            Post post = new Post()
            {
                Title = model.Title,
                Content = model.Content,
                Author = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value
            };

            await context.AddAsync(post);
            await context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(int id)
        {
            Post post = await context.Posts.FirstAsync(p => p.Id == id);
            context.Posts.Remove(post);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, PostFormModel model)
        {
            Post post = await context.Posts.FirstAsync(p=>p.Id == id);
            post.Content = model.Content;
            post.Title = model.Title;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostListViewModel>> GetAllAsync()
        {
            IEnumerable<PostListViewModel> allPosts = await context.Posts
                .Select(p => new PostListViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    Author = p.Author
                }).ToArrayAsync();

            return allPosts;
        }

        public async Task<PostFormModel> GetForEditOrDeleteById(int id)
        {
            Post post = await context.Posts.FirstAsync(p => p.Id == id);

            PostFormModel model = new PostFormModel()
            {
                
                Title = post.Title,
                Content = post.Content

            };

            return model;      
        }
    }
}
