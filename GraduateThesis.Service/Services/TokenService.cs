using GraduateThesis.Core.Configuration;
using GraduateThesis.Core.Dtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOptions<CustomTokenOption> _tokenOptions;


        public TokenService(UserManager<AppUser> userManager, IOptions<CustomTokenOption> tokenOptions)
        {
            _userManager = userManager;
            _tokenOptions = tokenOptions;
        }

        // TokenDto ile Geriye AccessToken + RefreshToken döndürdüğümüzden burada 2'sinide üretelim.
        public async Task<TokenDto> CreateTokenAsync(AppUser appUser)
        {
            // Expiration Times of TOKENS
            var JwtExpirationTime = DateTime.Now.AddMinutes(_tokenOptions.Value.AccessTokenExpirationTime);
            var refreshTokenExpirationTime = DateTime.Now.AddMinutes(_tokenOptions.Value.RefreshTokenExpirationTime);

            // Token'ı imzalayacak SecurityKey nesnesini oluşturalım
            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOptions.Value.SecurityKey);

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Token'ımızı üretelim;

            JwtSecurityToken jwt = new
                (
                    issuer: _tokenOptions.Value.Issuer,
                    expires: JwtExpirationTime,
                    notBefore: DateTime.Now,

                    claims: await GetClaims(appUser,_tokenOptions.Value.Audiences),
                    signingCredentials: signingCredentials
                );

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwt);

            return new TokenDto
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpirationTime = JwtExpirationTime,
                RefreshTokenExpirationTime = refreshTokenExpirationTime
            };

        }


        private async Task<IEnumerable<Claim>> GetClaims(AppUser appUser, List<string> audiences)
        {
            var userClaims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,appUser.Id),
                new(ClaimTypes.Name,appUser.FullName),
                new(ClaimTypes.Email,appUser.Email),
                new("user-universityId",appUser.UniversityId.ToString()),

                // her token için benzersiz bir Id üretelim;
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            // audiences listesinden gelen Audience'ları ekleyelim
            userClaims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            // user'ın birden fazla rolü olabilir.Her bir rolü claim olarak ekleyelim
            var userRoles = await _userManager.GetRolesAsync(appUser);

            if (userRoles.Any())
            {
                userClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            return userClaims;
        }

        // Benzersiz RefreshToken üreten metodumuz
        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }
    }
}
