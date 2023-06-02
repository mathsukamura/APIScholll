using Microsoft.AspNetCore.Mvc;
using Scholl.Helpers;
using Scholl.Services.ControleMenu.Interface;
using Scholl.ViewModels;
using System.Threading.Tasks;

namespace Scholl.Controllers
{
    [AuthorizeUrl("cadastromenu")]
    public class MenuController : Controller
    {
        private readonly IBuscarMenuService _buscarMenusService;
        private readonly IBuscarMenuService _buscarMenuService;
        private readonly ICriarMenuService _criarMenuService;
        private readonly IAlterarMenuService _alterarMenuService;
        private readonly IDeletarMenuService _deletarMenuService;

        public MenuController(IBuscarMenuService buscarMenuService,
            IBuscarMenuService buscarMenusServices,
            ICriarMenuService criarMenuService,
            IAlterarMenuService alterarMenuService,
            IDeletarMenuService deletarMenuService)
        {
            _buscarMenuService = buscarMenuService;
            _buscarMenusService = buscarMenusServices;
            _criarMenuService = criarMenuService;
            _alterarMenuService = alterarMenuService;
            _deletarMenuService = deletarMenuService;
        }

        [HttpGet("/api/v1/menu")]
        public async Task<IActionResult> GetAsync()
        {
            var menu = await _buscarMenusService.GetAsync();

            return Ok(menu);
        }

        [HttpGet("/api/v1/menu/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var menu = await _buscarMenuService.GetByIdAsync(id);

            return menu == null ? NotFound() : Ok(menu);
        }

        [HttpPost("/api/v1/menu")]
        public async Task<IActionResult> PostAsync([FromBody] CreateMenuViewModel model) 
        {

            var menu = await _criarMenuService.PostAsync(model);

            return Created($"v1/menu/{menu.Id}", new { menu.Id });
        }

        [HttpPut("/api/v1/menu/{id}")]
        public async Task<IActionResult> PutAsync( [FromBody] CreateMenuViewModel model,[FromRoute] int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var menu = await _alterarMenuService.PutAsync(model, id);

            if(menu == null)
            {
                return BadRequest();
            }
            return Ok(menu.Id);
        }

        [HttpDelete("/api/v1/menu/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id) 
        {
            var success = await _deletarMenuService.DeleteAsync(id);

            if (!success)
            {
                return BadRequest("menu Inesistente");
            }

            return Ok("Apagado com Sucesso");
        }
    }
}
