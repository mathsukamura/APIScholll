using Microsoft.AspNetCore.Mvc;
using Scholl.Helpers;
using Scholl.Services.Registrarperfil.Interface;
using Scholl.ViewModels;
using System.Threading.Tasks;

namespace Scholl.Controllers
{
    [AuthorizeUrl("cadastroperfil")]
    public class CrudPerfilController : Controller
    {
        private readonly IBuscarPerfilService _buscarPerfilService;
        private readonly IBuscarPerfilService _buscarPerfilsService;
        private readonly ICriarPerfilService _criarPerfilService;
        private readonly IAlterarPerfilService _alterarPerfilService;
        private readonly IDeletarPerfilService _deletarPerfilService;

        public CrudPerfilController(
            ICriarPerfilService criarPerfilService,
            IBuscarPerfilService buscarPerfilsService,
            IBuscarPerfilService buscarPerfilService,
            IAlterarPerfilService alterarPerfilService,
            IDeletarPerfilService deletarPerfilService)
        {
            _buscarPerfilsService = buscarPerfilsService;
            _buscarPerfilService= buscarPerfilService;
            _criarPerfilService = criarPerfilService;
            _alterarPerfilService = alterarPerfilService;
            _deletarPerfilService = deletarPerfilService;
        }

        [HttpGet("/api/v1/perfil")]
        public async Task<IActionResult> GetAsync()
        {
            var perfil = await _buscarPerfilsService.GetAsync();

            return Ok(perfil);
        }

        [HttpGet("/api/v1/perfil/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var perfil = await _buscarPerfilService.GetByIdAsync(id);

            return perfil == null ? NotFound() : Ok(perfil);
        }

        [HttpPost("/api/v1/perfil")]
        public async Task<IActionResult> PostAsync([FromBody] CreatePerfilViewModel model)
        {
            var perfil = await _criarPerfilService.PostAsync(model);

            return Created($"v1/professor/{perfil.Id}", new { perfil.Id });
        }

        [HttpPut("/api/v1/perfil/{id}")]
        public async Task<IActionResult> PutAsync(
        [FromBody] CreatePerfilViewModel model,
        [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var perfil = await _alterarPerfilService.PutAsync(model, id);

            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        [HttpDelete("/api/v1/perfil/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var success = await _deletarPerfilService.DeleteAsync(id);

            if (!success)
            {
                return BadRequest("ocorreu erro inesperado");
            }

            return Ok();
        }
    }
}