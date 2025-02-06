using DemoBlazor.Models;
using DemoBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

		public List<UserFromAPI> Users { get; set; }
        protected override async Task OnInitializedAsync()
        {
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7047/api/User");


			string? token = await _Stockage.GetItem<string>("token");
			if (token is not null)
			{
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
			}

			HttpResponseMessage? httpResponse = await _Http.SendAsync(request);

			if (httpResponse is not null && httpResponse.IsSuccessStatusCode)
            {
				Users = await httpResponse.Content.ReadFromJsonAsync<List<UserFromAPI>>();
			}
        }
    }
}
