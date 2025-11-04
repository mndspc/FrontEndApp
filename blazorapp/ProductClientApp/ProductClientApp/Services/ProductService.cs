using ProductClientApp.Models;
using System.Net.Http.Json;

namespace ProductClientApp.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Product>>("api/productinfo/GetAll") ?? new();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Product>($"api/productinfo/GetById/{id}");
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            var response = await _http.PostAsJsonAsync("api/productinfo/AddProduct", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var response = await _http.PutAsJsonAsync("api/productinfo/UpdateProduct", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/productinfo/DeleteProduct/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
