using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Pages
{
    public partial class ExempleBinding: ComponentBase
    {
        public string Nom { get; set; }
        public string Message { get; set; }

        public void DireBonjour()
        {
            Message = "Bonjour " + Nom;
        }
    }
}
