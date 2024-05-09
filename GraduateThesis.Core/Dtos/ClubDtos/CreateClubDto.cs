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
        public string ClubName { get; set; }

        public string ClubSummary { get; set; }

        //public string? ClubPhoto { get; set; }

        public bool IsClubActive { get; set; } = true;

        public IEnumerable<int> Categories { get; set; }
    }
}
