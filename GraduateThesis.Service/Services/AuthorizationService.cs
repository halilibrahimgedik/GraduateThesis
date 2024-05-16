using GraduateThesis.Core.Dtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.LoginDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Repositories;
using GraduateThesis.Core.Services;
using GraduateThesis.Core.UnitOfWork;
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
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IGenericRepository<UserRefreshToken> _userRefreshToken;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorizationService(ITokenService tokenService, UserManager<AppUser> userManager, IGenericRepository<UserRefreshToken> userRefreshToken, IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _userRefreshToken = userRefreshToken;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                throw new ArgumentNullException(nameof(LoginDto));
            }

            var existUser = await _userManager.FindByEmailAsync(loginDto.Email);

            if (existUser == null)
            {
                throw new ClientSideException("Email address or Password wrong.");
            }

            if (!await _userManager.CheckPasswordAsync(existUser, loginDto.Password))
            {
                throw new ClientSideException("Email address or Password wrong.");
            }

            var tokenDto = await _tokenService.CreateTokenAsync(existUser);

            // refreshToken'ı db'ye kaydedelim
            var userRefreshToken = await _userRefreshToken.Where(x => x.UserId == existUser.Id).SingleOrDefaultAsync();

            if (userRefreshToken == null)
            {
                var newUserRefreshToken = new UserRefreshToken
                {
                    UserId = existUser.Id,
                    ExpirationTime = tokenDto.RefreshTokenExpirationTime,
                    RefreshToken = tokenDto.RefreshToken,
                };

                await _userRefreshToken.AddAsync(newUserRefreshToken);
            }
            else
            {
                userRefreshToken.RefreshToken = tokenDto.RefreshToken;
                userRefreshToken.ExpirationTime = tokenDto.RefreshTokenExpirationTime;
            }

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<TokenDto>.Success(StatusCodes.Status200OK, tokenDto);
        }

        public async Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                return CustomResponseDto<TokenDto>.Fail(StatusCodes.Status400BadRequest, "refreshToken parameter can not be empty");
            }

            var userRefreshToken = await _userRefreshToken.Where(x => x.RefreshToken == refreshToken).SingleOrDefaultAsync() ?? throw new NotFoundException("refresh token not found");

            var user = await _userManager.FindByIdAsync(userRefreshToken.UserId) ?? throw new NotFoundException("user not found");

            // yeni bir TokenDto nesnesi
            var newToken = await _tokenService.CreateTokenAsync(user);

            // eski refresh token'ı günceleyelim
            userRefreshToken.RefreshToken = newToken.RefreshToken;
            userRefreshToken.ExpirationTime = newToken.RefreshTokenExpirationTime;

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<TokenDto>.Success(StatusCodes.Status200OK, newToken);
        }

        public async Task<CustomResponseDto<NoDataDto>> RevokeRefreshTokenAsync(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                throw new ClientSideException("refreshToken can not be empty");
            }

            var existUserRefreshToken = await _userRefreshToken.Where(x => x.RefreshToken == refreshToken).SingleOrDefaultAsync() ?? throw new NotFoundException("refreshToken not found");

            _userRefreshToken.Remove(existUserRefreshToken);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoDataDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
