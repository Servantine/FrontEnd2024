using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using utssapi.Models;

namespace utssapi.Services
{
    public class CategoriesService
    {
        private readonly HttpClient _httpClient;

        public CategoriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Categories>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Categories>>("api/v1/Categories");
        }

        public async Task<Categories> GetCategoryByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Categories>($"api/v1/Categories/{id}");
        }

        public async Task UpdateCategoryAsync(Categories categories)
        {
            await _httpClient.PutAsJsonAsync($"api/v1/Categories/{categories.categoryId}", categories);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/v1/Categories/{id}");
        }


        public async Task<Categories> CreateCategoryAsync(Categories newCategory)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/Categories", newCategory);

            if (response.IsSuccessStatusCode)
            {

                return await response.Content.ReadFromJsonAsync<Categories>();
            }
            else
            {

                throw new HttpRequestException($"Gagal menambahkan kategori. Status code: {response.StatusCode}");
            }
        }
    }
}