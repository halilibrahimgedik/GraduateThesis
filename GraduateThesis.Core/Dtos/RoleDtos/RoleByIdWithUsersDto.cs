using GraduateThesis.Core.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Dtos.RoleDtos
{
    public class RoleByIdWithUsersDto
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public List<AppUserDto> Users { get; set; }
    }
}
