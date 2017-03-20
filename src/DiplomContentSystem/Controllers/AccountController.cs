using DiplomContentSystem.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using DiplomContentSystem.Dto.Login;
using DiplomContentSystem.Authentication;

namespace DiplomContentSystem.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IAuthService loginService;

        public AccountController(IOptions<JwtIssuerOptions> jwtOptions, IAuthService service)
        {
            this.loginService = service;
            this._jwtOptions = jwtOptions.Value;
            service.ThrowIfInvalidOptions(_jwtOptions);

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            return await loginService.GetIdentity(user, _jwtOptions, _serializerSettings);
        }

        [HttpPost("refresh-identity")]
        public async Task<IActionResult> Refresh([FromBody] string token)
        {
            return await loginService.RefreshToken(token, _jwtOptions, _serializerSettings);
        }
    }
}

   