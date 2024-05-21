namespace GraduateThesis.WEB.Configurations
{
    public class CustomTokenOption
    {
        public List<String> Audiences { get; set; }

        public string Issuer { get; set; }

        public int AccessTokenExpirationTime { get; set; }

        public int RefreshTokenExpirationTime { get; set; }

        public string SecurityKey { get; set; }
    }
}
