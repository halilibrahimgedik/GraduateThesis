using GraduateThesis.WEB.Models.ClubViewModels;
using GraduateThesis.WEB.Models;
using GraduateThesis.WEB.Models.UniversityViewModels;

namespace GraduateThesis.WEB.Services.Concrete
{
    public class UniversityApiService
    {
        private readonly HttpClient _httpClient;
        public UniversityApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UniversitiesVm>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseVm<List<UniversitiesVm>>>("universities");

            return response.Data;
        }
    }
}
