using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.UniversityDtos
{
    public class UpdateUniversityDto
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public string Website { get; set; }
        public string Mail { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string Address { get; set; }
        public string? Rector { get; set; }
    }
}
