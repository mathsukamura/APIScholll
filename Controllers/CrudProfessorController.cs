using Microsoft.AspNetCore.Mvc;
using Scholl.ProfessorViewModel;
using Scholl.Services.registradorProfessor.Interfaces;
using Scholl.Services.RegistradorProfessor;
using System.Threading.Tasks;

namespace Scholl.Controllers
{
    public class CrudProfessorController : Controller
    {
        private readonly ICriarProfessorService _criarProfessorService;
        private readonly IDeletarProfessorService _deleteProfessorService;
        private readonly IAlterarProfessorService _alterarProfessorService;
        private readonly IBuscarProfessorService _buscarProfessoresService;
        private readonly IBuscarProfessorService _buscarProfessorService;

        public CrudProfessorController(
            ICriarProfessorService criarProfessorService,
            IDeletarProfessorService deleteProfessorService,
            IBuscarProfessorService buscarProfessoresService,
            IBuscarProfessorService buscarProfessorService,
            IAlterarProfessorService alterarProfessorService)
        {
            _criarProfessorService = criarProfessorService;
            _deleteProfessorService = deleteProfessorService;
            _buscarProfessoresService = buscarProfessoresService;
            _buscarProfessorService = buscarProfessorService;
            _alterarProfessorService = alterarProfessorService;
        }

        [HttpGet("professor")]
        public async Task<IActionResult> GetAsync()
        {
            var professor = await _buscarProfessoresService.GetAsync();

            return Ok(professor);
        }

        [HttpGet("professor/{id}")]
        public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id)
        {
            var professor = await _buscarProfessorService.GetByIdAsync(id);

            return professor == null ? NotFound() : Ok(professor);
        }

        [HttpPost("professor")]
        public async Task<IActionResult> PostAsync([FromBody] CreateProfessorViewModels model)
        {
            ProfessorValidador validator = new ProfessorValidador();

            var result = validator.Validate(model);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var professor = await _criarProfessorService.PostAsync(model);

            return Created($"v1/professor/{professor.Id}", new { professor.Id });
        }

        [HttpPut("professor/{Id}")]
        public async Task<IActionResult> PutAsync(
            [FromBody] CreateProfessorViewModels model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var professor = await _alterarProfessorService.PutAsync(model, id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [HttpDelete("professor/{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var success = await _deleteProfessorService.DeleteAsync(id);

            if (!success)
            {
                return BadRequest("ocorreu erro inesperado");
            }

            return Ok();
        }
    }
}