namespace GraduateThesis.WEB.Models.ViewModels
{
    public class ClubVm : BaseVm
    {
        public string ClubName { get; set; }

        public string ClubSummary { get; set; }

        public string ClubPhoto { get; set; }

        public bool IsClubActive { get; set; } = true;
    }
}
