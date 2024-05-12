using GraduateThesis.WEB.Models.CategoryViewModels;

namespace GraduateThesis.WEB.Models.ClubViewModels
{
    public class ClubWitCategoriesVm : ClubVm
    {
        public ICollection<CategoryVm> Categories { get; set; }
    }
}
