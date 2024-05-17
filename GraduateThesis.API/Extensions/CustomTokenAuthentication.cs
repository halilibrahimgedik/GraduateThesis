using GraduateThesis.Core.Configuration;
using GraduateThesis.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace GraduateThesis.API.Extensions
{
    public static class CustomTokenAuthentication
    {
        public static void AddCustomTokenAuthentication(this IServiceCollection services, CustomTokenOption tokenOption)
        {
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions =>
            {
                jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidIssuer = tokenOption.Issuer,
                    ValidAudience = tokenOption.Audiences?[0],
                    IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOption.SecurityKey),

                    // let's check incoming JWT for 4 condition
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,    // validate token lifetime
                    ClockSkew = TimeSpan.Zero,  // turning off 5 minutes added by default
                };
            });
        }
    }
}
