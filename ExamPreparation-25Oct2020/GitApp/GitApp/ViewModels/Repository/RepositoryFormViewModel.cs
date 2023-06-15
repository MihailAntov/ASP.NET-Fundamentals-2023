using System.ComponentModel.DataAnnotations;
using static GitApp.Common.ValidationConstants.Repository;
using GitApp.Common.Enums;
namespace GitApp.ViewModels.Repository
{
    public class RepositoryFormViewModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public RepositoryType RepositoryType { get; set; }

    }
}
