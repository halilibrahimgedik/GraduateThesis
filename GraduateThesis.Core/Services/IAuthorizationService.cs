using GraduateThesis.Core.Dtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.LoginDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Core.Services
{
    public interface IAuthorizationService
    {
        // Token Oluşturma, Refresh Token ile yeni Token Oluşturma ve RefreshToken'ı Db'den kaldırma işlemleri
        Task<CustomResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken);

        Task<CustomResponseDto<NoDataDto>> RevokeRefreshTokenAsync(string refreshToken);
    }
}
