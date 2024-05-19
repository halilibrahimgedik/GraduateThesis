using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.RoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IRoleService
    {
        Task<CustomResponseDto<RoleDto>> GetAllAsync();

        Task<CustomResponseDto<RoleDto>> GetRoleById(string roleId);

        Task<CustomResponseDto<RoleDto>> CreateRoleAsync(RoleDto dto);

        Task<CustomResponseDto<RoleDto>> UpdateRoleAsync(UpdateRoleDto dto);

        Task<CustomResponseDto<NoDataDto>> RemoveRoleAsync(string roleId);
    }
}
