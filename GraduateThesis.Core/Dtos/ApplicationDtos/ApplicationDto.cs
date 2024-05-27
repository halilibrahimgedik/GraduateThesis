using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.ApplicationDtos
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int ClubId { get; set; }

        public string Cv { get; set; }

        public string Description { get; set; }

        public bool isApproved { get; set; }
    }
}
