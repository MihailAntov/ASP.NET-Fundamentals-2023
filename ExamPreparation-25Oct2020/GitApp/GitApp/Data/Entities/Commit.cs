using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GitApp.Data.Entities
{
    public class Commit
    {
        [Key]
        public string Id { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
        
        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Creator))]
        [Required]
        public string CreatorId { get; set; } = null!;
        [Required]
        public ApplicationUser Creator { get; set; } = null!;

        [ForeignKey(nameof(Repository))]
        public string? RepositoryId { get; set; } 
        
        public Repository? Repository { get; set; }

    }
}
