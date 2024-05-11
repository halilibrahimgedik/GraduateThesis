namespace GraduateThesis.WEB.Models.ClubViewModels
{
    public class CreateClubVm
    {
        public string Name { get; set; }

        public string Summary { get; set; }

        public bool IsActive { get; set; } = true;

        public List<int> Categories { get; set; }
    }
}
