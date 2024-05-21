using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.SubscriberDtos
{
    public class DeleteSubscriberClubDto : SubscriberIdDto
    {
        public int ClubId { get; set; }
    }
}
