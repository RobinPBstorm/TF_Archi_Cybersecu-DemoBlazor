using DemoBlazor.Models.ConsommationAPI;
using DemoBlazor.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DemoBlazor.Services
{
    public class AuthService : IAuthService
	{
		private HttpClient _Http { get; set; }

		private IStockageService _Stockage { get; set; }

        public AuthService(HttpClient http,
							IStockageService stockage)
		{
			_Http = http;
			_Stockage = stockage;

        }

		public async Task Login(string username, string password)
		{
			object postBody = new { username = username, password = password };

			HttpResponseMessage responses = await _Http.PostAsJsonAsync("https://localhost:7047/api/Auth/Login", postBody);


			if (responses.IsSuccessStatusCode)
			{
				Tokens tokens = await responses.Content.ReadFromJsonAsync<Tokens>();

				await _Stockage.SetItem<string>("token", tokens.JWT);
				await _Stockage.SetItem<string>("refreshToken", tokens.RefreshToken);

            }
			else
			{
				throw new Exception(await responses.Content.ReadAsStringAsync());
			}
		}

		public async Task Logout()
		{
			await _Stockage.RemoveItem("token");
			await _Stockage.RemoveItem("refreshToken");

            // Éventuellement contacter l'API sur endpoint logout
            // Ce logout pourrait par exemple s'assurer que le refreshToken ne soit plus valide.
        }

		public async Task ChangePassword(string oldOne, string newOne)
		{
			object putBody = new { oldPassword = oldOne, newPassword = newOne };
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "https://localhost:7047/api/Auth/ChangePassword");

			request.Content = JsonContent.Create(putBody);
			
			string? token = await _Stockage.GetItem<string>("token");
			if (token is not null)
			{
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
			}
			HttpResponseMessage response = await _Http.SendAsync(request);

			if (!response.IsSuccessStatusCode)
			{
				string message = await response.Content.ReadAsStringAsync();
				throw new Exception(message);
			}
		}

		public async Task Register(UserRegisterForm user)
		{
			object postBody = user;

			HttpResponseMessage responses = await _Http.PostAsJsonAsync("https://localhost:7047/api/Auth/Register", postBody);

			if (!responses.IsSuccessStatusCode)
			{
				throw new Exception(await responses.Content.ReadAsStringAsync());
			}
		}
	}
}
