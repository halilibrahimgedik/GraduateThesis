namespace GraduateThesis.WEB.Models.ClubViewModels
{
    public class CreateClubWithImageVm
    {
        public CreateClubVm Club { get; set; }
        public IFormFile Image { get; set; }
    }
}
