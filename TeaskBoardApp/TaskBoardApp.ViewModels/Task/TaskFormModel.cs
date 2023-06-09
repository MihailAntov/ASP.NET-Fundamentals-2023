
using System.ComponentModel.DataAnnotations;
using TaskBoardApp.ViewModels.Board;
using static TaskBoardApp.Common.ValidationConstants.TaskConstants;

namespace TaskBoardApp.ViewModels.Task
{
    public class TaskFormModel
    {
        [MinLength(TaskTitleMinLength)]
        [MaxLength(TaskTitleMaxLength)]
        [Required]
        public string Title { get; set; } = null!;

        [MinLength(TaskDescriptionMinLength)]
        [MaxLength(TaskDescriptionMaxLength)]
        [Required]
        public string Description { get; set; } = null!;
        public int BoardId { get; set; }
        public string? OwnerId { get; set; }

        public IEnumerable<BoardSelectViewModel>? Boards { get; set; }
    }
}
