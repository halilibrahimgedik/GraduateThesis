﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.SubscriberDtos
{
    public class SubsClubsDto
    {
        public int ClubId { get; set; }
        public string ClubName { get; set; }

        public string ClubSummary { get; set; }

        public string? ClubUrl { get; set; }
    }
}
