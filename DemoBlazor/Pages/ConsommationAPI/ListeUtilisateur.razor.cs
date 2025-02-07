using DemoBlazor.Models.ConsommationAPI;
using DemoBlazor.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DemoBlazor.Pages.ConsommationAPI
{
    public partial class ListeUtilisateur: ComponentBase
    {
        [Inject]
        private HttpClient _Http { get; set; }

		[Inject]
		private IStockageService _Stockage { get; set; }

		public string ErreurMessage { get; set; } = string.Empty;

        public List<UserFromAPI> Users { get; set; }

		public bool IsLoading { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
			IsLoading = true;
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7047/api/User");
			try
			{
				HttpResponseMessage? httpResponse = await _Http.SendAsync(request);

				if (httpResponse.IsSuccessStatusCode)
				{
					Users = await httpResponse.Content.ReadFromJsonAsync<List<UserFromAPI>>();
					IsLoading = false;
				}
				else if (httpResponse is not null)
				{
					ErreurMessage = await httpResponse.Content.ReadAsStringAsync();

					IsLoading = false;
				}
			}
			catch(Exception exception)
			{
				ErreurMessage = "Le serveur ne répond pas!";
				IsLoading = false;
			}

        }
    }
}
