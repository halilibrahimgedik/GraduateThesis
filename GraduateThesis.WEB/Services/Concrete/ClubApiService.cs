using GraduateThesis.WEB.Models;
using GraduateThesis.WEB.Models.ClubViewModels;
using System.Text.Json;

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

        //public async Task<ClubVm> SaveAsync(ClubVm newProduct)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("clubs", newProduct);

        //    if (!response.IsSuccessStatusCode) return null;

        //    var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseVm<ClubVm>>();

        //    return responseBody.Data;
        //}


        public async Task<CustomResponseVm<ClubVm>> SaveAsync(CreateClubWithImageVm newProduct)
        { 
            var multipartContent = new MultipartFormDataContent();

            multipartContent.Add(new StringContent(newProduct.Name), "Name");
            multipartContent.Add(new StringContent(newProduct.Summary), "Summary");
            multipartContent.Add(new StringContent(newProduct.IsActive.ToString()), "IsActive");

            foreach (var category in newProduct.Categories)
            {
                multipartContent.Add(new StringContent(category.ToString()), "Categories");
            }

            var imageContent = new StreamContent(newProduct.Image.OpenReadStream());
            multipartContent.Add(imageContent, "Image", newProduct.Image.FileName);

            var response = await _httpClient.PostAsync("clubs", multipartContent);

            if (!response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<CustomResponseVm<ClubVm>>())!;
            }

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseVm<ClubVm>>();

            return responseBody!;
        }

        public async Task<bool> UpdateAsync(UpdateClubVM newProduct)
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
