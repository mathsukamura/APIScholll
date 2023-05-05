using Microsoft.AspNetCore.Mvc;
using Scholl.AvaliacaoViewModel;
using Scholl.Services.RegistrarAvaliacao.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Scholl.Data;
using Scholl.Services.registradorProfessor.Interfaces;

namespace Scholl.Controllers
{
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly ICriarAvalicaoService _criarAvaliacaoService;
        private readonly IAlterarAvalicaoService _alterarAvalicaoService;
        private readonly IDeleteAvaliacaoService _deleteAvaliacaoService;
        private readonly IBuscarAvaliacaoService _buscarAvaliacoesService;
        private readonly IBuscarAvaliacaoService _buscarAvaliacaoService;

        public AvaliacaoController(
            ICriarAvalicaoService criarAvaliacaoService,
            IAlterarAvalicaoService alterarAvalicaoService,
            IDeleteAvaliacaoService deleteAvaliacaoService,
            IBuscarAvaliacaoService buscarAvaliacoesService,
            IBuscarAvaliacaoService buscarAvaliacaoService)
        {
            _criarAvaliacaoService = criarAvaliacaoService;
            _alterarAvalicaoService = alterarAvalicaoService;
            _deleteAvaliacaoService= deleteAvaliacaoService;
            _buscarAvaliacoesService = buscarAvaliacoesService;
            _buscarAvaliacaoService = buscarAvaliacaoService;
        }

        [HttpGet("avaliacao")]
        public async Task<IActionResult> GetAsync()
        {
            var avaliacao = await _buscarAvaliacoesService.GetAsync();

            return Ok(avaliacao);
        }

        [HttpGet("avaliacao/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var avaliacao = await _buscarAvaliacaoService.GetByIdAsync(id);

            return avaliacao == null ? NotFound() : Ok(avaliacao);
        }

        [HttpPost("avaliacao")]
        //[Authorize(Roles = "Professor")]
        public async Task<IActionResult> PostAsync([FromBody] CreateAvaliacaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var result = await _criarAvaliacaoService.PostAsync(model);

            return Ok(result);
        }

        [HttpPut("avaliacao/{id}")]
        //[Authorize(Roles = "Professor")]
        public async Task<IActionResult> PutAsync([FromBody] CreateAvaliacaoViewModel model, int id)
        {
            var result = await _alterarAvalicaoService.PutAsync(model, id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("avaliacao/{id}")]
        //[Authorize(Roles = "Professor")]
        public async Task<IActionResult> DeleteAsync([FromBody] CreateAvaliacaoViewModel model, [FromRoute]int id) 
        {
            var success = await _deleteAvaliacaoService.DeleteAsync(model, id);

            if (!success)
            {
                return BadRequest("ocorreu erro inesperado");
            }
            return Ok(success);
        }
    }
}
