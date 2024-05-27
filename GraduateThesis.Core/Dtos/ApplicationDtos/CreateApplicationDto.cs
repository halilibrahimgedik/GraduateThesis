using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.ApplicationDtos
{
    public class CreateApplicationDto
    {
        public string AppUserId { get; set; }
        public int ClubId { get; set; }

        public IFormFile CvFile { get; set; }

        public string Description { get; set; }
    }
}
