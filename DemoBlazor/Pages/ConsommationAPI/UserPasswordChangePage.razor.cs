using DemoBlazor.Models.ConsommationAPI;
using DemoBlazor.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Pages.ConsommationAPI
{
    public partial class UserPasswordChangePage : ComponentBase
	{
		[Inject]
		private IStockageService _Stockage { get; set; }
        [Inject]
        private IAuthService _authService { get; set; }

		public string ResponseMessage { get; set; } = string.Empty;
        public bool IsResponseAnError { get; set; } = true;
        public bool IsConnected { get; set; }

        public PasswordChangeForm PasswordChangeModel { get; set; } = new PasswordChangeForm();

        protected override async Task OnInitializedAsync()
        {
            IsConnected = false;

            string? token = await _Stockage.GetItem<string>("token");
            if (token is null)
            {
                ResponseMessage = "Opéraion impossible: vous n'étes pas connecté";
                IsResponseAnError = true;

			}
            else
            {
                ResponseMessage = string.Empty;
                IsConnected = true;

            }
        }

        public async void SendChangingPasswordRequest()
        {
			ResponseMessage = string.Empty;
			try
            {
                await _authService.ChangePassword(PasswordChangeModel.OldPassword, PasswordChangeModel.NewPassword);
                ResponseMessage = "Votre mot de passe a été changé";
				IsResponseAnError = false;

				// refresh le rendu
				StateHasChanged();
			}
            catch(Exception exception)
            {
                ResponseMessage = exception.Message;
				IsResponseAnError = true;

                // refresh le rendu
				StateHasChanged();
			}
        }
    }
}
