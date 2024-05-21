using GraduateThesis.Core.Dtos.AppUserDtos;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    public class UsersController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateAppUserDto dto)
        {
            return CreateAction(await _userService.CreateUserAsync(dto));
        }

        //[Authorize(AuthenticationSchemes="Bearer",Roles ="admin")]
        [HttpPost("getuserinfo/{mail}")]
        public async Task<IActionResult> GetUserInfoByEmail(string mail)
        {
            return CreateAction(await _userService.GetUserByEmailAsync(mail));
        }
    }
}
