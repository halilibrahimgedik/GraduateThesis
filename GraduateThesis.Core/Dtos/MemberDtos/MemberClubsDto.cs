using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.MemberDtos
{
    public class MemberClubsDto : MemberIdDto
    {
        public List<MemberClubDto> MemberClubs { get; set; } = new List<MemberClubDto>();
    }
}
