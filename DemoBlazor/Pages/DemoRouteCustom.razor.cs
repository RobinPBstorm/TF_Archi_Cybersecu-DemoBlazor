using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace DemoBlazor.Pages
{
	public partial class DemoRouteCustom: ComponentBase
	{
		[Parameter]
        public int monParameter { get; set; }

		public void NaviguerVersCompteur()
		{
			navigation.NavigateTo("/Counter");
		}

		public void AugmenterMonParametre()
		{
			monParameter += 1;
        }
    }
}
