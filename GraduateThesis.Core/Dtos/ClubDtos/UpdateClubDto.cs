using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.ClubDtos
{
    public class UpdateClubDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public bool IsActive { get; set; }
        public List<int> Categories { get; set; }

        public int ClubUniversityId { get; set; }
        public IFormFile? Image { get; set; }
    }
}
