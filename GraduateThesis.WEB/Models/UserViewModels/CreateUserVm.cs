namespace GraduateThesis.WEB.Models.UserViewModels
{
    public class CreateUserVm
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UniversityId { get; set; }
    }
}
