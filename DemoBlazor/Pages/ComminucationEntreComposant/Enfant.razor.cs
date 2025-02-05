using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Pages.ComminucationEntreComposant
{
	public partial class Enfant: ComponentBase
	{
        [Parameter]
        public int ValeurDepuisParent { get; set; }

        [Parameter]
		public EventCallback<int> RepondreAuParent { get; set; }

		private void EnvoyerReponseAuParent()
		{
			RepondreAuParent.InvokeAsync(ValeurDepuisParent);
		}
	}
}
