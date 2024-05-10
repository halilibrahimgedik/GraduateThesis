using GraduateThesis.Core.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.ClubDtos
{
    public class CreateClubDto
    {
        public string Name { get; set; }

        public string Summary { get; set; }

        public bool IsActive { get; set; } = true;

        public List<int> Categories { get; set; }
    }
}
