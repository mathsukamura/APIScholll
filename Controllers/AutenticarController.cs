using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholl.LoginModel;
using Scholl.Services.GerarToken.Interface;
using System.Threading.Tasks;



namespace Scholl.Controllers
{
    [ApiController]
    [Route("api/login")]
    [AllowAnonymous]
    public class AutenticarController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IAutenticarUsuario _autenticarUsuario;

        public AutenticarController( ITokenService tokenService, IAutenticarUsuario autenticarUsuario)
        {
            _tokenService = tokenService;
            _autenticarUsuario = autenticarUsuario;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> AutenticacaoAsync([FromBody] Login Logins)
        {
            var usuario = await _autenticarUsuario.AutenticacaoAsync(Logins);
            if (usuario == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            var token = _tokenService.GerarToken(usuario);
            return Ok(new {token});
        }
    }
}
