﻿using DemoBlazor.Models.ConsommationAPI;
using DemoBlazor.Services;
using DemoBlazor.Services.Interfaces;
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
        private IAuthService _authService { get; set; }

        public LoginModel Login { get; set; } = new LoginModel();

        public string ErreurMessage { get; set; } = string.Empty;

        public async Task Connection()
        {
            try
            {
                await _authService.Login(Login.Username, Login.Password);

                Navigation.NavigateTo("/ExerciceAPI");
			}
            catch(Exception exception)
            {
                ErreurMessage = exception.Message;
            }
        }
    }
}
