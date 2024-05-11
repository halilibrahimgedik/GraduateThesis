namespace GraduateThesis.WEB.Models.ClubViewModels
{
    public class ClubVm : BaseVm
    {
        public string Name { get; set; }

        public string Summary { get; set; }

        public string? Url { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
