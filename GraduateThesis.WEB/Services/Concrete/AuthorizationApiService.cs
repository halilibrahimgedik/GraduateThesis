using GraduateThesis.WEB.Models;
using GraduateThesis.WEB.Models.LoginViewModels;

namespace GraduateThesis.WEB.Services.Concrete
{
    public class AuthorizationApiService
    {
        private readonly HttpClient _httpClient;
        public AuthorizationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<CustomResponseVm<TokenVm>> CreateToken(LoginVm loginVm)
        {
            var response = await _httpClient.PostAsJsonAsync("auth", loginVm);

            var responseData = await response.Content.ReadFromJsonAsync<CustomResponseVm<TokenVm>>();

            if(!response.IsSuccessStatusCode)
            {
                return CustomResponseVm<TokenVm>.Fail(responseData.Errors);
            }

            return responseData;
        }
    }
}
