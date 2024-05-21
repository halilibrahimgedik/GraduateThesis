using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }


        public List<Club> ClubAppUsers { get; set; }
    }
}
