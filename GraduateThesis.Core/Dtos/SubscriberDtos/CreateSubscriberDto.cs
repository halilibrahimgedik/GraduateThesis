using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.SubscriberDtos
{
    public class CreateSubscriberDto : SubscriberIdDto
    {
        public int ClubId { get; set; }
    }
}
