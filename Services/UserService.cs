using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Scholl.Services
{
    public interface IUserService
    {
        int ObterUsuarioId();
    }

    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int ObterUsuarioId()
        {
           return int.Parse(_httpContextAccessor?.HttpContext?.User!.FindFirstValue(JwtRegisteredClaimNames.Sid));
        }
    }
}
