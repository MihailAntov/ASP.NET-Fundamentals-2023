
namespace GitApp.Data.Entities
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.ValidationConstants.Repository;
    public class Repository
    {
        [Key]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; } 

        [Required]
        public bool IsPublic { get; set; }

        [ForeignKey(nameof(Owner))]
        
        public string? OwnerId { get; set; }

        
        public ApplicationUser? Owner { get; set; }
        public virtual ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
