namespace GraduateThesis.WEB.Models
{
    public class TokenVm
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime AccessTokenExpirationTime { get; set; }

        public DateTime RefreshTokenExpirationTime { get; set; }
    }
}
