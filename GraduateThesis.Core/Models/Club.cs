using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Models
{
    public class Club : BaseEntity
    {
        public string ClubName { get; set; }

        public string ClubSummary { get; set; }

        public string ClubPhoto { get; set; }

        public bool IsClubActive { get; set; } = true;

        public ICollection<ClubCategory> ClubCategories { get; set; }
    }
}
