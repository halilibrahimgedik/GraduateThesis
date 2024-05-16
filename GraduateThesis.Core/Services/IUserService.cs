using GraduateThesis.Core.Dtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IUserService : IGenericService<AppUser, AppUserDto>
    {
        // User CRUD işlemleri 

    }
}
