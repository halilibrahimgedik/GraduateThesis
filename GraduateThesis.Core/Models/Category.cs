using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public ICollection<ClubCategory>? ClubCategories { get; set; }
    }
}
