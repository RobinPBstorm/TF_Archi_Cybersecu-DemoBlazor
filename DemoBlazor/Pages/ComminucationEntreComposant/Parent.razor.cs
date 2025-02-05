using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Pages.ComminucationEntreComposant
{
    public partial class Parent: ComponentBase
    {
        public int ValeurAffiche { get; set; }

        public void RecevoirReponseEnfant(int valeurRecue)
        {
            ValeurAffiche = valeurRecue;
        }
    }
}
