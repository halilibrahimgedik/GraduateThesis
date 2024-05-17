using GraduateThesis.Core.Dtos;
using GraduateThesis.Core.Dtos.LoginDtos;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{

    public class AuthorizationsController : CustomBaseController
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationsController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
           return CreateAction(await _authorizationService.CreateTokenAsync(loginDto));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            return CreateAction(await _authorizationService.CreateTokenByRefreshTokenAsync(refreshTokenDto.RefreshToken));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            return CreateAction(await _authorizationService.RevokeRefreshTokenAsync(refreshTokenDto.RefreshToken));
        }
    }
}
