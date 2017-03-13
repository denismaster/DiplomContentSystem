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

namespace DiplomContentSystem.Controllers
{
    public class LoginViewModel
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Should this user be remembered next time attempting to view secured pages
        /// </summary>
        public bool RememberMe { get; set; }
    }
    public interface ILoginService
    {
        Task<ObjectResult> GetIdentity(LoginViewModel user, JwtIssuerOptions _jwtOptions, JsonSerializerSettings _serializerSettings);
        Task<ObjectResult> RefreshToken(string token, JwtIssuerOptions _jwtOptions, JsonSerializerSettings _serializerSettings);
        void ThrowIfInvalidOptions(JwtIssuerOptions options);
    }
    public class LoginService : ILoginService
    {
        //private readonly IRepositoryManager _repository;

        public LoginService(/*IRepositoryManager repository*/)
        {
            // _repository = repository;
        }

        public async Task<ObjectResult> GetIdentity(LoginViewModel user, JwtIssuerOptions _jwtOptions, JsonSerializerSettings _serializerSettings)
        {
            if (string.IsNullOrEmpty(user.Username))
            {
                var authenticationResult = new
                {
                    Succeeded = false,
                    Message = "Пользователь не зарегистрирован"
                };
                return new ObjectResult(authenticationResult);
            }

            var identity = await GetClaimsIdentity(user);
            if (identity == null)
            {
                var authenticationResult = new
                {
                    Succeeded = false,
                    Message = "Неверный пароль"
                };

                return new ObjectResult(authenticationResult);
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst(AuthConsts.ClaimUserType)
            };

            var encodedJwt = CreateJWTToken(claims, user.RememberMe, _jwtOptions);

            return TokenResult(encodedJwt, user.RememberMe ? (int)_jwtOptions.RememberValidFor.TotalSeconds : (int)_jwtOptions.ValidFor.TotalSeconds, _jwtOptions, _serializerSettings);
        }

        private ObjectResult TokenResult(string token, double expires, JwtIssuerOptions _jwtOptions, JsonSerializerSettings _serializerSettings)
        {
            var response = new
            {
                token = token,
                expires = expires
            };
            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }

        public async Task<ObjectResult> RefreshToken(string token, JwtIssuerOptions _jwtOptions, JsonSerializerSettings _serializerSettings)
        {
            JwtSecurityToken tok = new JwtSecurityTokenHandler().ReadJwtToken(token);

            // if remember token and token expire balance > expire of short token - return
            // in other cases extend short token or convert remember token to short (to live working session)
            if (tok.ValidTo - tok.ValidFrom == _jwtOptions.RememberValidFor && (tok.ValidTo - _jwtOptions.IssuedAt) > _jwtOptions.ValidFor)
            {
                return TokenResult(token, (int)_jwtOptions.RememberValidFor.TotalSeconds, _jwtOptions, _serializerSettings);
            }

            // extend token's expiration
            var expiration = _jwtOptions.Expiration;

            var user = tok.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value;
            var identity = await GetClaimsIdentity(user);
            if (identity == null)
            {
                var refreshTokenResult = new
                {
                    Succeeded = false,
                    Message = "Пользователь не зарегистрирован"
                };
                return new ObjectResult(refreshTokenResult);
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst(AuthConsts.ClaimUserType)
            };

            var encodedJwt = RefreshJWTToken(claims, expiration, _jwtOptions);

            return TokenResult(encodedJwt, (int)_jwtOptions.ValidFor.TotalSeconds, _jwtOptions, _serializerSettings);
        }

        public void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.RememberValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.RememberValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }

        private string RefreshJWTToken(Claim[] claims, DateTime expiration, JwtIssuerOptions _jwtOptions)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: expiration,
                signingCredentials: _jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private string CreateJWTToken(Claim[] claims, bool rememberMe, JwtIssuerOptions _jwtOptions)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: rememberMe ? _jwtOptions.RememberExpiration : _jwtOptions.Expiration,
                signingCredentials: _jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private Task<ClaimsIdentity> GetClaimsIdentity(LoginViewModel user)
        {
            ///  var dbUser = _repository.GetCommonReadonlyRepository<Core.User>().Find().ToArray().FirstOrDefault(u => u.Login == user.Username && PasswordUtils.Verify(user.Password, u.PasswordHash));
            var dbUser = new User(user.Username);
            if (dbUser != null)
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(dbUser.Login, "Token"),
                    dbUser.IsAdmin
                    ? new Claim[] { new Claim(AuthConsts.ClaimUserType, AuthConsts.RoleAdmin) }
                    : new Claim[] { new Claim(AuthConsts.ClaimUserType, AuthConsts.RoleUser
                    ) }));
            }

            return Task.FromResult<ClaimsIdentity>(null);
        }

        private Task<ClaimsIdentity> GetClaimsIdentity(string user)
        {
            var dbUser = new User(user);
            //var dbUser = _repository.GetCommonReadonlyRepository<DataLayer.Entities.User>().Find().ToArray().FirstOrDefault(u => u.Login == user);
            if (dbUser != null)
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(dbUser.Login, "Token"),
                    dbUser.IsAdmin
                    ? new Claim[] { new Claim(AuthConsts.ClaimUserType, AuthConsts.RoleAdmin) }
                    : new Claim[] { new Claim(AuthConsts.ClaimUserType, AuthConsts.RoleUser
                    ) }));
            }

            return Task.FromResult<ClaimsIdentity>(null);
        }
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
        internal class User
        {
            public bool IsAdmin = true;
            public string Login;

            public User(string username)
            {
                this.Login = username;
            }
        }
    }
}

   