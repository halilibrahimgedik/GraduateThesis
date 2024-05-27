using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.AnnouncementDtos
{
    public class CreateAnnouncementDto
    {
        public string Header { get; set; }

        public string Description { get; set; }


        public string Publisher { get; set; }

        public int ClubId { get; set; }
    }
}
