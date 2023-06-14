namespace Library.Models.Book
{
	using System.ComponentModel.DataAnnotations;
	using static Library.Common.BookValidationConstants;
	public class BookFormViewModel
	{
		[MinLength(BookTitleMinLength)]
		[MaxLength(BookTitleMaxLength)]
		[Required]
		public string Title { get; set; } = null!;

		[MinLength(BookAuthorMinLength)]
		[MaxLength(BookAuthorMaxLength)]
		[Required]
		public string Author { get; set; } = null!;

		[Required]
		[MaxLength(BookDescriptionMaxLength)]
		[MinLength(BookDescriptionMinLength)]
		public string Description { get; set; } = null!;

		[Required]
		public string Url { get; set; } = null!;

		[Required]
		[Range(0.00,10.00)]
		public decimal Rating { get; set; }


		public IEnumerable<CategoryListViewModel> Categories { get; set; } = null!;

		[Required]
		public int CategoryId { get; set; }

	}
}
