using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.SubscriberDtos
{
    public class SubscriberClubsDto
    {
        public string UserId { get; set; }

        public List<SubsClubsDto> SubscribersClubs { get; set; } = new List<SubsClubsDto>();
        //public int ClubId { get; set; }
        //public string ClubName { get; set; }
        //public string ClubSummary { get; set; }
        //public string? Url { get; set; }

    }
}
