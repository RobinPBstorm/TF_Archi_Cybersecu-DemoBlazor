using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models.ConsommationAPI
{
	public class UserRegisterForm
	{
		[Required]
		[MaxLength(100)]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[Required]
		[MaxLength(100)]
		public string Firstname { get; set; }
	}
}
