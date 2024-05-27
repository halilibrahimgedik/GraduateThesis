using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Models
{
    public class Club : BaseEntity
    {
        public string Name { get; set; }

        public string Summary { get; set; }

        public string? Url { get; set; }

        public bool IsActive { get; set; }


        public int ClubUniversityId { get; set; }
        public University ClubUniversity { get; set; }


        public List<ClubAppUser>? ClubAppUsers { get; set; }

        public ICollection<ClubCategory> ClubCategories { get; set; } = new List<ClubCategory>();

        public List<ClubPresident> ClubPresidents { get; set; }

        public List<Announcement> Announcements { get; set; }
    }
}
