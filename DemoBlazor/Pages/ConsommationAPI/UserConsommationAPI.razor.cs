using DemoBlazor.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Pages.ConsommationAPI
{
	public partial class UserConsommationAPI: ComponentBase
	{
        [Inject]
        private IAuthService _authService { get; set; }

        public void Logout()
        {
            _authService.Logout();
        }
    }
}
