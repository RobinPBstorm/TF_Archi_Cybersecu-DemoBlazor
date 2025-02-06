using DemoBlazor.Models;
using DemoBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace DemoBlazor.Pages.ConsommationAPI
{
    public partial class LoginPage : ComponentBase
    {
        [Inject]
        private NavigationManager Navigation { get; set; }
        [Inject]
        private HttpClient Http { get; set; }
        [Inject]
        private IJSRuntime _js { get; set; }

        [Inject]
        private IStockageService _stockage { get; set; }

        public LoginModel Login { get; set; } = new LoginModel();

        public async Task Connection()
        {
            object postBody = new { username = Login.Username, password = Login.Password };
            HttpResponseMessage responses = await Http.PostAsJsonAsync("https://localhost:7047/api/Auth/Login", postBody);
            

            if  (responses.IsSuccessStatusCode)
            {
                Tokens tokens = await responses.Content.ReadFromJsonAsync<Tokens>();

                await _stockage.SetItem<string>("token", tokens.JWT);
                await _stockage.SetItem<string>("refreshToken", tokens.RefreshToken);
                
                Navigation.NavigateTo("/listeUtilisateur");
            }
        }
    }
}
