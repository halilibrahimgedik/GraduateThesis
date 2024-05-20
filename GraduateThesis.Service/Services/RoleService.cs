using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.RoleDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Services;
using GraduateThesis.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task<CustomResponseDto<NoDataDto>> AssignRoleAsync(AssignRoleDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId) ?? throw new NotFoundException("user not found");

            var role = await _roleManager.FindByIdAsync(dto.RoleId) ?? throw new NotFoundException("role not found0");

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (!result.Succeeded)
            {
                return CustomResponseDto<NoDataDto>.Fail(StatusCodes.Status500InternalServerError, "something went wrong. pls contact system admin");
            }

            return CustomResponseDto<NoDataDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<RoleDto>> CreateRoleAsync(CreateRoleDto dto)
        {
            var doesRoleExist = await _roleManager.RoleExistsAsync(dto.RoleName) ? throw new ClientSideException($" already added this '{dto.RoleName}' !") : false;

            var role = ObjectMapper.Mapper.Map<IdentityRole>(dto);

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return CustomResponseDto<RoleDto>.Fail(StatusCodes.Status500InternalServerError, "something went wrong, pls contact your system admin");
            }

            var roleDto = ObjectMapper.Mapper.Map<RoleDto>(dto);

            return CustomResponseDto<RoleDto>.Success(StatusCodes.Status201Created, roleDto);
        }

        public async Task<CustomResponseDto<List<RoleDto>>> GetAllAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync() ?? throw new ArgumentNullException("There is no any user.");

            var roleDtos = ObjectMapper.Mapper.Map<List<RoleDto>>(roles);

            return CustomResponseDto<List<RoleDto>>.Success(StatusCodes.Status200OK, roleDtos);
        }

        public async Task<CustomResponseDto<RoleDto>> GetRoleByIdAsync(string roleId)
        {
            if (string.IsNullOrEmpty(roleId)) { throw new ClientSideException(nameof(roleId)); }

            var role = await _roleManager.FindByIdAsync(roleId) ?? throw new NotFoundException("role not found !");

            var roleDto = ObjectMapper.Mapper.Map<RoleDto>(role);

            return CustomResponseDto<RoleDto>.Success(StatusCodes.Status200OK, roleDto);
        }

        public async Task<CustomResponseDto<List<RoleByIdWithUsersDto>>> GetRoleByIdWithUsersAsync(string roleId)
        {
            if (string.IsNullOrEmpty(roleId)) { throw new ClientSideException("roleId can not be empty"); }

            var users = await _userManager.GetUsersInRoleAsync(roleId);

            if (!users.Any()) { CustomResponseDto<RoleByIdWithUsersDto>.Fail(StatusCodes.Status400BadRequest, "there are no users with the specified Id"); }

            var roleByIdWithUsersDtoList = ObjectMapper.Mapper.Map<List<RoleByIdWithUsersDto>>(users);

            return CustomResponseDto<List<RoleByIdWithUsersDto>>.Success(StatusCodes.Status200OK,roleByIdWithUsersDtoList);
        }

        public async Task<CustomResponseDto<NoDataDto>> RemoveRoleAsync(string roleId)
        {
            if (string.IsNullOrEmpty(roleId)) { throw new ClientSideException("role id can not be empty"); }

            var role = await _roleManager.FindByIdAsync(roleId) ?? throw new ArgumentNullException("role not found !");

            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded) { CustomResponseDto<NoDataDto>.Fail(StatusCodes.Status500InternalServerError, "something went wrong !"); }

            return CustomResponseDto<NoDataDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<NoDataDto>> UpdateRoleAsync(UpdateRoleDto dto)
        {
            var role = await _roleManager.FindByIdAsync(dto.RoleId) ?? throw new NotFoundException("role not found !");

            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded)
            {
                CustomResponseDto<RoleDto>.Fail(StatusCodes.Status500InternalServerError, "something went wrong !");
            }

            return CustomResponseDto<NoDataDto>.Success(StatusCodes.Status200OK);
        }
    }
}
