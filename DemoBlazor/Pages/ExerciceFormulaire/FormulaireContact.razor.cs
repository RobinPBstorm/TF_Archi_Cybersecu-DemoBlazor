using DemoBlazor.Models;
using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Pages.ExerciceFormulaire
{
	public partial class FormulaireContact: ComponentBase
	{
		public Utilisateur utilisateur { get; set; } = new Utilisateur();

        public bool FormulaireValideEtEnvoye { get; set; } = false;
		public bool MessageErreur { get; set; } = false;

        public void EnvoyerFormulaireValide()
		{
			MessageErreur = false;
			FormulaireValideEtEnvoye = true;
		}
		public void SignalerFormulaireInvalide()
		{
			MessageErreur = true;
		}

	}
}
