using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Models
{
    public class ClubAppUser
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int ClubId { get; set; }
        public Club Club { get; set; }
    }
}
