namespace GraduateThesis.WEB.Models.ViewModels
{
    public class ProductWithCategoryVm : BaseVm
    {
        public string CategoryName { get; set; }

        public List<ClubVm> Clubs { get; set; }
    }
}
