namespace GraduateThesis.WEB.Models.ClubViewModels
{
    public class CreateClubVm
    {
        public string ClubName { get; set; }

        public string ClubSummary { get; set; }

        public string? ClubPhoto { get; set; }

        public bool IsClubActive { get; set; } = true;

        public List<int> Categories { get; set; }
    }
}
