using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.AppUserDtos
{
    public class AppUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public int UniversityId { get; set; }
    }
}
