using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Common.ValidationConstants.TaskConstants;


namespace TaskBoardApp.Data.Models.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TaskDescriptionMaxLength)]

        public string Description { get; set; } = null!;


        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }

        public Board? Board { get; set; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;


        public IdentityUser Owner { get; set; } = null!;
    }
}
