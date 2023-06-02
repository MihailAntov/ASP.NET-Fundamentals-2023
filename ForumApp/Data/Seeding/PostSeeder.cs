using Forum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Seeding
{
    internal class PostSeeder
    {


        public Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();

            posts.Add(new Post()
            {
                Id = 1,
                Title = "First Post",
                Content = "This is the first post. Added by seeding.",
                Author = "Unknown"

            });

            posts.Add(new Post()
            {
                Id = 2,
                Title = "Second Post",
                Content = "This is the second post. Added by seeding.",
                Author = "Unknown"

            });

            posts.Add(new Post()
            {
                Id = 3,
                Title = "Third Post",
                Content = "This is the third post. Added by seeding.",
                Author = "Unknown"

            });

            return posts.ToArray();
        }
    }
}
