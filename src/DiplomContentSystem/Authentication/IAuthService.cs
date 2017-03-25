using DiplomContentSystem.Dto.Login;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DiplomContentSystem.Authentication
{
    public interface IAuthService
    {
        Task<ObjectResult> GetIdentity(LoginDto user, JwtIssuerOptions _jwtOptions, JsonSerializerSettings _serializerSettings);
        Task<ObjectResult> RefreshToken(string token, JwtIssuerOptions _jwtOptions, JsonSerializerSettings _serializerSettings);
        void ThrowIfInvalidOptions(JwtIssuerOptions options);
    }
}
