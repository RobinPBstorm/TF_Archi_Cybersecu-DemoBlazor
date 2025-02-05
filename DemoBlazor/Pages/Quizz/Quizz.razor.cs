using DemoBlazor.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace DemoBlazor.Pages.Quizz
{
    public partial class Quizz: ComponentBase
    {
        [Parameter]
        public string Nom { get; set; }
		[Parameter]
		public EventCallback<string> EnvoyerReponse { get; set; }
		[Parameter]
		public EventCallback SignalerFinQuizz { get; set; }

		public List<Question> Questions { get; set; }
		public int IndexQuestion { get; set; } = 0;

        public Quizz()
		{
			Questions = new List<Question>();
			Questions.Add(new Question("Avez-vous bien mangé ?", new List<string> { "oui", "non" }));
		}

		public void EnvoyerMaReponse(string reponse)
		{
			EnvoyerReponse.InvokeAsync(reponse);
			QuestionSuivante();
		}

		private void QuestionSuivante()
		{
			IndexQuestion++;
			if (IndexQuestion >= Questions.Count)
			{
				SignalerFinQuizz.InvokeAsync();
			}
		}

	}
}
