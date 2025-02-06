using DemoBlazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using System.Threading.Tasks.Dataflow;

namespace DemoBlazor.Pages.Form
{
	public partial class FilmFormulaire:ComponentBase
	{
        public string Message { get; set; }
        public FilmModel Film { get; set; } = new FilmModel();

        public void SubmitForm()
        {
            Message = "le film est envoyé";
        }
    }
}
