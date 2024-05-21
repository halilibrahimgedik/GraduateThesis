namespace GraduateThesis.WEB.Models.UniversityViewModels
{
    public class UniversitiesVm : BaseVm
    {
        public string UniversityName { get; set; }
        public string Website { get; set; }
        public string Mail { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string Address { get; set; }
        public string? Rector { get; set; }
    }
}
