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
            // Multipart form verisini oluştur
            var multipartContent = new MultipartFormDataContent();

            // Club verisini JSON formatına dönüştür ve ekleyin
            //var clubJson = JsonSerializer.Serialize(newProduct.Club);
            multipartContent.Add(new StringContent(newProduct.Club.ClubName), "Club.ClubName");
            multipartContent.Add(new StringContent(newProduct.Club.ClubSummary), "Club.ClubSummary");
            multipartContent.Add(new StringContent(newProduct.Club.IsClubActive.ToString()), "Club.IsClubActive");
            foreach (var category in newProduct.Club.Categories)
            {
                multipartContent.Add(new StringContent(category.ToString()), "Club.Categories");
            }

            // Dosyayı ekleyin
            var imageContent = new StreamContent(newProduct.Image.OpenReadStream());
            multipartContent.Add(imageContent, "Image", newProduct.Image.FileName);

            // API'ye POST isteği gönderin
            var response = await _httpClient.PostAsync("clubs", multipartContent);

            // Yanıtı kontrol edin
            if (!response.IsSuccessStatusCode)
            {
                // Yanıt başarısız ise null döndürün veya isteği yeniden deneyin veya hata işleyin
                return null;
            }

            // Yanıtı okuyun ve JSON formatına dönüştürün
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseVm<ClubVm>>();

            return responseBody;

            //var response = await _httpClient.PostAsJsonAsync("clubs", newProduct);

            ////if (!response.IsSuccessStatusCode) return null;

            //var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseVm<ClubVm>>();

            //return responseBody;
        }

        //public async Task<bool> UpdateAsync(ClubVm newProduct)
        //{
        //    var response = await _httpClient.PutAsJsonAsync("clubs", newProduct);

        //    return response.IsSuccessStatusCode;
        //}

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
