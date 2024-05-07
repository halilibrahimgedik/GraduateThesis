using GraduateThesis.WEB.Models;
using GraduateThesis.WEB.Services.Abstract;
using System.Net.Http;

namespace GraduateThesis.WEB.Services.Concrete
{
    public class ApiService<TViewModel> : IApiService<TViewModel> where TViewModel : class
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<TViewModel>> GetAllAsync(string endpoint)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseVm<List<TViewModel>>>(endpoint);
            return response.Data;
        }

        public async Task<TViewModel> GetByIdAsync(int id, string endpoint)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseVm<TViewModel>>(endpoint);
            return response.Data;
        }

        public async Task<bool> RemoveAsync(int id, string endpoint)
        {
            var response = await _httpClient.DeleteAsync($"{endpoint}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<TViewModel> SaveAsync(TViewModel newEntity, string endpoint)
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, newEntity);

            if (!response.IsSuccessStatusCode)
            {
                // Handle error
                return new CustomResponseVm<TViewModel>().Data;
            }

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseVm<TViewModel>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(TViewModel entity, string endpoint)
        {
            var response = await _httpClient.PutAsJsonAsync(endpoint, entity);
            return response.IsSuccessStatusCode;
        }
    }
}
