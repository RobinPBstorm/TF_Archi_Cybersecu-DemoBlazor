using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models
{
	public class FilmModel
	{
        public int Id { get; set; }

		// Datannotation avec le message d'erreur d'indiqué
        [Required(ErrorMessage = "Le titre du film est requis")]
		[MaxLength(100, ErrorMessage = "Le titre ne peut dépasser 100 caractères.")]
		public string Titre { get; set; }

		[Required]
		[Range(1970, 2250)]
		public int AnneeSortie { get; set; }

    }
}
