

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Task = TaskBoardApp.Data.Models.Entities.Task;

namespace TaskBoardApp.Data.Configuration
{
    internal class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Models.Entities.Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateTasks());
        }

        private ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {
                new Task()
                {
                    Id = 1,
                    Title = "Improve CSS",
                    Description = "Meaningless text to fill the space",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = "1fc63949-d658-419e-898f-a9936bfac86d",
                    BoardId = 1
                },
                new Task()
                {
                    Id = 2,
                    Title = "Android App",
                    Description = "Meaningless text to fill the space",
                    CreatedOn = DateTime.Now.AddDays(-5),
                    OwnerId = "1fc63949-d658-419e-898f-a9936bfac86d",
                    BoardId = 1
                },
                new Task()
                {
                    Id = 3,
                    Title = "Desktop App",
                    Description = "Meaningless text to fill the space",
                    CreatedOn = DateTime.Now.AddDays(-1),
                    OwnerId = "1fc63949-d658-419e-898f-a9936bfac86d",
                    BoardId = 2
                },
                new Task()
                {
                    Id = 4,
                    Title = "Create Tasks",
                    Description = "Meaningless text to fill the space",
                    CreatedOn = DateTime.Now.AddDays(-1),
                    OwnerId = "1fc63949-d658-419e-898f-a9936bfac86d",
                    BoardId = 3
                }
            };

            return tasks;
        }
    }
}
