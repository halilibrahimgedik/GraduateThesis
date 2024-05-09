using GraduateThesis.WEB.Models;
using GraduateThesis.WEB.Models.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.WEB.Services.Concrete
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;
        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryVm>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseVm<List<CategoryVm>>>("categories");
            return response.Data;
        }

        public async Task<CategoryVm> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseVm<CategoryVm>>($"categories/{id}");
            return response.Data;
        }

        public async Task<CategoryVm> AddAsync(CreateCategoryVm newCategoryVm)
        {
            var response = await _httpClient.PostAsJsonAsync("categories", newCategoryVm);
            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseVm<CategoryVm>>();

            return responseBody.Data;
        }

        public async Task<bool> Update(UpdateCategoryVm updateVm)
        {
            var response = await _httpClient.PutAsJsonAsync("clubs", updateVm);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"categories/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
