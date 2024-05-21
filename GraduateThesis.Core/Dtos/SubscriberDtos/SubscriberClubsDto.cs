using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.SubscriberDtos
{
    public class SubscriberClubsDto : SubscriberIdDto
    {
        public List<SubsClubsDto> SubscribersClubs { get; set; } = new List<SubsClubsDto>();
    }
}
