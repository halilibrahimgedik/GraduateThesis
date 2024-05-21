using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.AppUserDtos
{
    public class AppUserInfoDto : AppUserDto
    {
        public List<string> UserRoles { get; set; }
    }
}
