using System.ComponentModel.DataAnnotations;
using static GitApp.Common.ValidationConstants.Commit;
namespace GitApp.ViewModels.Commit
{
    public class CommitFormViewModel
    {
        [Required]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string RepositoryId { get; set; } = null!;


    }
}
