namespace GraduateThesis.WEB.Models.ClubViewModels
{
    public class UpdateClubVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public bool IsActive { get; set; } = true;
        public List<int> Categories { get; set; }

        public string? Url { get; set; }

        public IFormFile? Image { get; set; }
    }
}
