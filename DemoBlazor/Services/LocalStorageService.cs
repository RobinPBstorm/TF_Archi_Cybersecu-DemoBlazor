
using DemoBlazor.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace DemoBlazor.Services
{
    public class LocalStorageService : IStockageService
	{
		private IJSRuntime _js { get; set; }

		public LocalStorageService (IJSRuntime js)
		{
			_js = js;
		}

		public async Task<T> GetItem<T>(string key)
		{
			string? json = await _js.InvokeAsync<string>("localStorage.getItem", key);
			if (json is null)
			{
				return default;
			}
			return JsonSerializer.Deserialize<T>(json);
		}

		public async Task RemoveItem(string key)
		{
			await _js.InvokeVoidAsync("localStorage.removeItem", key);
		}

		public async Task SetItem<T>(string key, T value)
		{
			await _js.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
		}
	}
}
