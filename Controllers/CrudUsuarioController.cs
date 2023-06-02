using Microsoft.AspNetCore.Mvc;
using Scholl.Services.RegistrarUsuario.Interface;
using System.Threading.Tasks;
using Scholl.ViewModels;
using Microsoft.AspNetCore.Mvc.Routing;
using Scholl.ProfessorViewModel;
using Scholl.Helpers;

namespace Scholl.Controllers
{
    [ApiController]
    [AuthorizeUrl("cadastrousuario")]
    public class CrudUsuarioController : ControllerBase
    {
        private readonly IBuscarUsuarioService _buscarUsuarioService;
        private readonly IBuscarUsuarioService _buscarUsuariosService;
        private readonly ICriarUsuarioService _criarUsuarioService;
        private readonly IAlterarUsuarioService _alterarUsuarioService;
        private readonly IDeletarUsarioService _deletarUsarioService;

        public CrudUsuarioController(
            IBuscarUsuarioService buscarUsuarioService,
            IBuscarUsuarioService buscarUsuariosService,
            ICriarUsuarioService criarUsuarioService,
            IAlterarUsuarioService alterarUsuarioService,
            IDeletarUsarioService deletarUsarioService) 
        { 
            _alterarUsuarioService= alterarUsuarioService;
            _buscarUsuarioService= buscarUsuarioService;
            _buscarUsuariosService = buscarUsuariosService;
            _criarUsuarioService = criarUsuarioService;
            _deletarUsarioService= deletarUsarioService;
        }

        [HttpGet("api/v1/usuario")]

        public async Task<IActionResult> GetAsync() 
        {
            var usuario = await _buscarUsuarioService.GetAsync();
            return Ok(usuario);
        }

        [HttpGet("api/v1/usuario/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id) 
        {
            var usuario = await _buscarUsuariosService.GetByIdAsync(id);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        [HttpPost("api/v1/usuario")]
        public async Task<IActionResult> PostAsync([FromBody] CreateUsuarioViewModel model)
        {
            var usuario = await _criarUsuarioService.PostAsync(model);

            return Created($"v1/usuario/{usuario.Id}", new { usuario.Id });
        }

        [HttpPut("api/v1/usuario/{Id}")]
        public async Task<IActionResult> PutAsync([FromBody] CreateUsuarioViewModel model,[FromRoute] int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuario = await _alterarUsuarioService.PutAsync(model, id);

            if(usuario == null) 
            {
                return BadRequest();
            }
            return Ok(usuario.Id);
        }

        [HttpDelete("api/v1/usuario/{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id) 
        {
            var success = await _deletarUsarioService.DeleteAsync(id);
            if (!success)
            {
                return BadRequest("ocorreu erro inesperado");
            }
            return Ok("Deletado com sucesso");

        }
    }
}
