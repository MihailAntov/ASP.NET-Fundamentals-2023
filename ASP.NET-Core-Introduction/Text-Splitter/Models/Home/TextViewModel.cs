using System.ComponentModel.DataAnnotations;

namespace Text_Splitter.Models.Home
{
	public class TextViewModel
	{
		[Required]
		[MinLength(2),MaxLength(30)]
		public string Text { get; set; } = null!;


		public string? SplitText { get; set; } = null!;
	}
}
