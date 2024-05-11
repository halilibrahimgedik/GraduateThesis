namespace GraduateThesis.WEB.Models.ClubViewModels
{
    public class UpdateClubVM
    {
        //public int Id { get; set; }
        //public string ClubName { get; set; }

        //public string ClubSummary { get; set; }

        //public string ClubPhoto { get; set; }

        //public bool IsClubActive { get; set; } = true;

        //public List<int> CategoryIds { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public bool IsActive { get; set; } = true;
        public List<int> Categories { get; set; }

        public IFormFile Image { get; set; }
    }
}
