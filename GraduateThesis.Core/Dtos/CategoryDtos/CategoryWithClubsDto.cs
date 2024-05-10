using GraduateThesis.Core.Dtos.ClubDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.CategoryDtos
{
    public class CategoryWithClubsDto :BaseDto
    {
        public string Name { get; set; }

        public List<ClubDto> Clubs { get; set; }
    }
}
