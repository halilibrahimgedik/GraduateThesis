using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.ClubDtos
{
    public class CreateClubWithImageDto
    {
        public CreateClubDto Club { get; set; }
        public IFormFile Image { get; set; }
    }
}
