using System.ComponentModel.DataAnnotations;
using static CarShop.Common.ValidationConstants.Issue;

namespace CarShop.ViewModels.Issue
{
    public class IssueFormViewModel
    {
        [Required]
        public Guid CarId { get; set; } 

        [Required]
        [MinLength(DescriptionMinLength)]

        public string Description { get; set; } = null!;
    }
}
