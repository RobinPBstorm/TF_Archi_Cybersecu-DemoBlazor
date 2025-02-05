using System.ComponentModel;

namespace DemoBlazor.Models
{
    public class Question
    {
        public string Intitule { get; set; }
        public List<string> Propositions { get; set; }
        public string? BonneReponse { get; set; }

		public Question(string intitule, List<string> propositions, string? bonneReponse = null)
		{
			Intitule = intitule;
			Propositions = propositions;
			BonneReponse = bonneReponse;
		}
	}
}
