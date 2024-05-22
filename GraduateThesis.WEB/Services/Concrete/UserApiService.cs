using GraduateThesis.WEB.Models;
using GraduateThesis.WEB.Models.CategoryViewModels;
using GraduateThesis.WEB.Models.UserViewModels;

namespace GraduateThesis.WEB.Services.Concrete
{
    public class UserApiService
    {
        private readonly HttpClient _httpClient;
        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<CustomResponseVm<UserVm>> CreateUserAsync(CreateUserVm createUserVm)
        {
            var response = await _httpClient.PostAsJsonAsync("users/createuser", createUserVm);

            var result = await response.Content.ReadFromJsonAsync<CustomResponseVm<UserVm>>();

            if (!response.IsSuccessStatusCode)
            {       
                return CustomResponseVm<UserVm>.Fail(result.Errors);
            }

            return result;
        }

    }
}
