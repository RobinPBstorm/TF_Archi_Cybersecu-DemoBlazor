using DemoBlazor.Models.ConsommationAPI;
using DemoBlazor.Services;
using DemoBlazor.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace DemoBlazor.Pages.ConsommationAPI
{
    public partial class RegisterPage : ComponentBase
    {
        [Inject]
        private NavigationManager Navigation { get; set; }

        [Inject]
        private IAuthService _authService { get; set; }

        public UserRegisterForm RegisterModel { get; set; } = new UserRegisterForm();

        public string ErreurMessage { get; set; } = string.Empty;

        public async Task Register()
        {
            try
            {
                await _authService.Register(RegisterModel);

                Navigation.NavigateTo("/Login");
			}
            catch(Exception exception)
            {
                ErreurMessage = exception.Message;
            }
        }
    }
}
