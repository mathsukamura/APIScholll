using Microsoft.AspNetCore.Mvc;
using Scholl.AvaliacaoViewModel;
using Scholl.Services.RegistrarAvaliacao.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Scholl.Data;
using Scholl.Services.registradorProfessor.Interfaces;
using Scholl.Helpers;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Scholl.Controllers
{
    [ApiController]
    [AuthorizeUrl("avaliacao")]
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
            _deleteAvaliacaoService = deleteAvaliacaoService;
            _buscarAvaliacoesService = buscarAvaliacoesService;
            _buscarAvaliacaoService = buscarAvaliacaoService;
        }
        [HttpGet("/api/v1/avaliacao")]

        public async Task<IActionResult> GetAsync()
        {
            var avaliacao = await _buscarAvaliacoesService.GetAsync();

            return Ok(avaliacao);
        }
        [HttpGet("/api/v1/avaliacao/{id}")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var avaliacao = await _buscarAvaliacaoService.GetByIdAsync(id);

            return avaliacao == null ? NotFound() : Ok(avaliacao);
        }

        [HttpPost("/api/v1/avaliacao")]

        public async Task<IActionResult> PostAsync([FromBody] CreateAvaliacaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var result = await _criarAvaliacaoService.PostAsync(model);

            return Ok(result);
        }

        [HttpPut("/api/v1/avaliacao/{id}")]

        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateAvaliacaoViewModel model)
        {
            var idUsuario = int.Parse(User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var result = await _alterarAvalicaoService.PutAsync(id, model);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("/api/v1/avaliacao/{id}")]
        public async Task<IActionResult> DeleteAsync(int id) 
        {
            var success = await _deleteAvaliacaoService.DeleteAsync(id);

            if (!success)
            {
                return BadRequest("ocorreu erro inesperado");
            }
            return Ok(success);
        }
    }
}
