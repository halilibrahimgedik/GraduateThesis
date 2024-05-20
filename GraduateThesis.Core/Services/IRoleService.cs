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
        Task<CustomResponseDto<List<RoleDto>>> GetAllAsync();

        Task<CustomResponseDto<RoleDto>> GetRoleByIdAsync(string roleId);

        Task<CustomResponseDto<List<RoleByIdWithUsersDto>>> GetRoleByIdWithUsersAsync(string roleId);

        Task<CustomResponseDto<RoleDto>> CreateRoleAsync(CreateRoleDto dto);

        Task<CustomResponseDto<NoDataDto>> UpdateRoleAsync(UpdateRoleDto dto);

        Task<CustomResponseDto<NoDataDto>> RemoveRoleAsync(string roleId);


        Task<CustomResponseDto<NoDataDto>> AssignRoleAsync(AssignRoleDto dto);
    }
}
