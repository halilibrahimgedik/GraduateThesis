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
        public string Id { get; set; }
        public string Name { get; set; }

        public AppUserDto User { get; set; }
    }
}
