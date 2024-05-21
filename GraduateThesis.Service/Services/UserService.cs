using GraduateThesis.Core.Dtos.AppUserDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Services;
using GraduateThesis.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<CustomResponseDto<AppUserDto>> CreateUserAsync(CreateAppUserDto dto)
        {
            var appUser = ObjectMapper.Mapper.Map<AppUser>(dto);

            var result = await _userManager.CreateAsync(appUser, dto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return CustomResponseDto<AppUserDto>.Fail(StatusCodes.Status500InternalServerError, errors);
            }

            var appuserDto = ObjectMapper.Mapper.Map<AppUserDto>(appUser);

            return CustomResponseDto<AppUserDto>.Success(StatusCodes.Status201Created, appuserDto);
        }

        public async Task<CustomResponseDto<AppUserInfoDto>> GetUserByEmailAsync(string mail)
        {
            if (string.IsNullOrEmpty(mail))
            {
                throw new ClientSideException("mail can not be empty");
            }

            var user = await _userManager.FindByEmailAsync(mail) ?? throw new NotFoundException($"There is no any user with email adress : {mail}");

            var userRoleList = await _userManager.GetRolesAsync(user);

            var appUserDto = ObjectMapper.Mapper.Map<AppUserInfoDto>(user);

            if (userRoleList.Any())
            {
                appUserDto.UserRoles = userRoleList.ToList();
            }

            return CustomResponseDto<AppUserInfoDto>.Success(StatusCodes.Status200OK, appUserDto);
        }

        public async Task<CustomResponseDto<AppUserDto>> UpdateUserAsync(UpdateAppUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id) ?? throw new NotFoundException($"The user specified by user id({dto.Id}) was not found");

            var appUser = ObjectMapper.Mapper.Map<AppUser>(dto);

            var resut = await _userManager.UpdateAsync(appUser);

            if (!resut.Succeeded)
            {
                return CustomResponseDto<AppUserDto>.Fail(StatusCodes.Status500InternalServerError, "Something went wrong,pls try again later");
            }

            var appUserDto = ObjectMapper.Mapper.Map<AppUserDto>(appUser);

            return CustomResponseDto<AppUserDto>.Success(StatusCodes.Status200OK, appUserDto);
        }

    }
}
