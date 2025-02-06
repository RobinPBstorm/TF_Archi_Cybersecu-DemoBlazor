using DemoBlazor.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Diagnostics;

namespace DemoBlazor.Pages.Quizz
{
    public partial class ExoQuizz: ComponentBase
    {
        public string NomParticipant { get; set; }
        public List<string> ReponsesParicipant { get; set; } = new List<string>();
        public bool PartieFinie { get; set; } = false;

        public void maReponse(string reponseRecue)
        {
            ReponsesParicipant.Add(reponseRecue);
        }

        public void FinDuQuizz()
        {
            PartieFinie = true;
        }

    }
}
