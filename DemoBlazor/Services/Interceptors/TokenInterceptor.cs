using DemoBlazor.Services.Interfaces;

namespace DemoBlazor.Services.Interceptors
{
	public class TokenInterceptor : DelegatingHandler
	{
		private IStockageService _Stockage { get; set; }
		public TokenInterceptor(IStockageService stockage)
		{
			_Stockage = stockage;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			string token = await _Stockage.GetItem<string>("token");
			if (!string.IsNullOrEmpty(token))
			{
				request.Headers.Add("Authorization", "bearer " + token);
			}
			return await base.SendAsync(request, cancellationToken);
		}

	}
}
