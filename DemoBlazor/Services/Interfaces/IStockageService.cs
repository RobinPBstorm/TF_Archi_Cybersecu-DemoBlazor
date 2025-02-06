namespace DemoBlazor.Services
{
    public interface IStockageService
    {
        public Task<T> GetItem<T>(string key);
        public Task SetItem<T>(string key, T value);
        public Task RemoveItem(string key);
	}
}
