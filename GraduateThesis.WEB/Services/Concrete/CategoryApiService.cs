using GraduateThesis.WEB.Models.ViewModels;

namespace GraduateThesis.WEB.Services.Concrete
{
    public class CategoryApiService : ApiService<CategoryVm>
    {
        public CategoryApiService(HttpClient httpClient) : base(httpClient)
        {
        }

    }
}
