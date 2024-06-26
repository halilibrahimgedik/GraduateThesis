﻿using GraduateThesis.Core.Dtos.CategoryDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.ClubDtos
{
    public class ClubDto : BaseDto
    {
        public string Name { get; set; }

        public string Summary { get; set; }

        public string? Url { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
