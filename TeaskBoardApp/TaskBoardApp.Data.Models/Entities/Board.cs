
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.ValidationConstants.BoardConstants;
namespace TaskBoardApp.Data.Models.Entities
{
    public class Board
    {
        public Board()
        {
            Tasks = new HashSet<Task>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual IEnumerable<Task> Tasks { get; set; } = null!;
    }
}
