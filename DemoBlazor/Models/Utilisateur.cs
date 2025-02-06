using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models
{
	public class Utilisateur
	{
        [Required]
        public string Nom { get; set; }

		[Required]
		[EmailAddress]
        public string Email { get; set; }

		[Required]
		[Phone]
        public string Telephone { get; set; }


		[Required]
		public string Message { get; set; }

		[Required]
		public string CouleurPreferee { get; set; }
    }
}
