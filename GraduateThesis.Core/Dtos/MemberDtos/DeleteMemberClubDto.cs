using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.MemberDtos
{
    public class DeleteMemberClubDto : MemberIdDto
    {
        public int ClubId { get; set; }
    }
}
