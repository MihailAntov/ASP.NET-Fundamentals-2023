using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models.Message
{
	public class MessageViewModel
	{
		[MinLength(1),MaxLength(255)]
		public string Sender { get; set; } = null!;

		[MinLength(2),MaxLength(25)]
		public string Message { get; set; } = null!;
	}
}
