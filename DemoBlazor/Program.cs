using DemoBlazor;
using DemoBlazor.Services;
using DemoBlazor.Services.Interceptors;
using DemoBlazor.Services.Interfaces;
using DemoBlazor.Services.MyAuthenticationState;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddTransient<IStockageService, LocalStorageService>();
builder.Services.AddSingleton<AuthenticationStateProvider, MyAuthStateProvider>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddTransient<TokenInterceptor>();

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("clientWithToken", sp =>
{
	new HttpClient();
	sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
}).AddHttpMessageHandler<TokenInterceptor>();
builder.Services.AddScoped<HttpClient>(sp => sp.GetRequiredService<IHttpClientFactory>()
									.CreateClient("clientWithToken"));


await builder.Build().RunAsync();
