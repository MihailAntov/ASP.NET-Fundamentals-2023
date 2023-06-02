using Forum.Data.Models;
using Forum.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Configuration
{
    internal class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        private readonly PostSeeder seeder;
            public PostEntityConfiguration()
        {
            this.seeder = new PostSeeder();
        }
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(this.seeder.GeneratePosts());
        }
    }
}
