using GraduateThesis.WEB.Models;
using GraduateThesis.WEB.Models.ViewModels;

namespace GraduateThesis.WEB.Services.Concrete
{
    public class ClubApiService
    {
        private readonly HttpClient _httpClient;
        public ClubApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ClubVm>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseVm<List<ClubVm>>>("clubs");

            return response.Data;
        }

        public async Task<ClubVm> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseVm<ClubVm>>($"clubs/{id}");

            return response.Data;
        }

        public async Task<ClubVm> SaveAsync(ClubVm newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("clubs", newProduct);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseVm<ClubVm>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(ClubVm newProduct)
        {
            var response = await _httpClient.PutAsJsonAsync("clubs", newProduct);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"clubs/{id}");

            return response.IsSuccessStatusCode;
        }



    }
}
