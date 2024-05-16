using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; }

        public string RefreshToken  { get; set; }

        public DateTime AccessTokenExpirationTime { get; set; }

        public DateTime RefreshTokenExpirationTime { get; set; }
    }
}
