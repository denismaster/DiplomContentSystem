using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiplomContentSystem.Services
{
    public interface ILoginService
    {
        Task<ObjectResult> GetIdentity(LoginDto user, JwtIssuerOptions _jwtOptions, JsonSerializerSettings _serializerSettings);
        Task<ObjectResult> RefreshToken(string token, JwtIssuerOptions _jwtOptions, JsonSerializerSettings _serializerSettings);
        void ThrowIfInvalidOptions(JwtIssuerOptions options);
    }
}