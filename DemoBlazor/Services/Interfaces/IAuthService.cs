using DemoBlazor.Models.ConsommationAPI;

namespace DemoBlazor.Services.Interfaces
{
	public interface IAuthService
	{
		public Task Login(string username, string password);
		public Task Logout();
		public Task ChangePassword(string oldOne, string newOne);
		public Task Register(UserRegisterForm user);
	}
}
