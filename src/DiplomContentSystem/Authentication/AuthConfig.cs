using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Authentication
{
    public static class AuthConfig
    {
        public static IServiceCollection AddAuthPolicy(this IServiceCollection service)
        {
            return service.AddAuthorization(options =>
            {
                options.AddPolicy(AuthConsts.PolicyAdmin,
                                  policy => policy.RequireClaim(AuthConsts.ClaimUserType,AuthConsts.Admin));
                options.AddPolicy(AuthConsts.PolicyStudent,
                                  policy => policy.RequireClaim(AuthConsts.ClaimUserType, AuthConsts.Student));
                options.AddPolicy(AuthConsts.PolicyTeacher,
                                  policy => policy.RequireClaim(AuthConsts.ClaimUserType, AuthConsts.Teacher));
                options.AddPolicy(AuthConsts.PolicyInstitute,
                                  policy => policy.RequireClaim(AuthConsts.ClaimUserType, AuthConsts.Institute));
                options.AddPolicy(AuthConsts.PolicyUser,
                                  policy => policy.RequireClaim(AuthConsts.ClaimUserType,AuthConsts.Admin, AuthConsts.Student, AuthConsts.Teacher, AuthConsts.Institute));
            });
        }

        public static IServiceCollection ConfigureJwtIssuerOptions(this IServiceCollection service, IConfiguration configuration, SymmetricSecurityKey _signingKey)
        {
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            return service.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = "DCS";//jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = "DCS";// jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });
        }

        public static IApplicationBuilder ConfigureJwtBearerAuthentication(this IApplicationBuilder app, IConfiguration configuration, SymmetricSecurityKey _signingKey)
        {
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "DCS",// jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = "DCS",// jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            return app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,

                TokenValidationParameters = tokenValidationParameters
            });
        }
    }
}
