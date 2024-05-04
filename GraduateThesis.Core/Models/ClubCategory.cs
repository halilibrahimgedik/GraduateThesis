using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Models
{
    public class ClubCategory
    {
        public int ClubId { get; set; }
        public Club Club { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
