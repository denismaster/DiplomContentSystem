using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly ILoginService loginService;

        public AccountController(IOptions<JwtIssuerOptions> jwtOptions, ILoginService service)
        {
            this.loginService = service;
            this._jwtOptions = jwtOptions.Value;
            service.ThrowIfInvalidOptions(_jwtOptions);

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel user)
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
