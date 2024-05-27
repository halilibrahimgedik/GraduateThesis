using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.AnnouncementDtos
{
    public class UpdateAnnouncementDto
    {
        public int Id { get; set; }
        public string Header { get; set; }

        public string Message { get; set; }


        public string AppUserId { get; set; }

        public int ClubId { get; set; }
    }
}
