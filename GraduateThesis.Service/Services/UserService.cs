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

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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

        public async Task<CustomResponseDto<AppUserDto>> GetUserByEmail(string mail)
        {
            if (string.IsNullOrEmpty(mail))
            {
                throw new ClientSideException("mail can not be empty");
            }

            var user = await _userManager.FindByEmailAsync(mail);

            if (user == null)
            {
                throw new NotFoundException($"There is no any user with email adress : {mail}");
            }

            var appUserDto = ObjectMapper.Mapper.Map<AppUserDto>(user);

            return CustomResponseDto<AppUserDto>.Success(StatusCodes.Status200OK, appUserDto);
        }
    }
}
