using GraduateThesis.Core.Dtos;
using GraduateThesis.Core.Dtos.AppUserDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IUserService
    {
        // User CRUD işlemleri 
        Task<CustomResponseDto<AppUserDto>> CreateUserAsync(CreateAppUserDto dto);

        Task<CustomResponseDto<AppUserInfoDto>> GetUserByEmailAsync(string mail);

        Task<CustomResponseDto<AppUserDto>> UpdateUserAsync(UpdateAppUserDto dto);
    }
}
