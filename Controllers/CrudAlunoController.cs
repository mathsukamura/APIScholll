using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scholl.Data;
using Scholl.AlunoViewModel;
using Scholl.AlunoModel;
using Scholl.Services.Alunos;
using Microsoft.EntityFrameworkCore;
using Scholl.Services.RegistradorAluno.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Scholl.Helpers;

namespace Scholl.CadastroAlunoControlller
{
    [AuthorizeUrl("cadastroaluno")]
    public class CrudAlunoController : ControllerBase
    {
        private readonly IBuscarAlunoService _buscarAlunoService;
        private readonly IBuscarAlunoService _buscarAlunosService;
        private readonly ICriarAlunoService _alunoService;
        private readonly IAlterarAlunoService _alterarAlunoService;
        private readonly IDeletarAlunoService _deleteAlunoService;
        public CrudAlunoController(
            ICriarAlunoService alunoService, 
            IDeletarAlunoService deleteAlunoService, 
            IBuscarAlunoService buscarAlunosService, 
            IBuscarAlunoService buscarAlunoService, 
            IAlterarAlunoService alterarAlunoService)
        {
            _alunoService = alunoService;
            _deleteAlunoService = deleteAlunoService;
            _buscarAlunosService = buscarAlunosService;
            _buscarAlunoService = buscarAlunoService;
            _alterarAlunoService = alterarAlunoService;
        }
        
        [HttpGet("api/v1/alunos")]
        //[Authorize(Policy = "Get")]
        public async Task<IActionResult> GetAsync()
            {
            var alunos = await _buscarAlunoService.GetAsync();

            return Ok(alunos);
            }

        [HttpGet("api/v1/alunos/{id}")]
        //[Authorize(Policy = "Get")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id)
            {
            var aluno = await _buscarAlunosService.GetByIdAsync(id);

            return aluno == null ? NotFound() : Ok(aluno);
            }
        
        [HttpPost("api/v1/alunos")]
        //[Authorize(Policy = "Post")]
        public async Task<IActionResult> PostAsync([FromBody] CreateAlunoViewModels model)
        {
            AlunoValidator validator = new AlunoValidator();
            
            var result = validator.Validate(model);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var aluno = await _alunoService.PostAsync(model);

            return Created($"v1/alunos/{aluno.Id}", new { aluno.Id });
        }
        
        [HttpPut("api/v1/alunos/{id}")]
        //[Authorize(Policy = "Put")]
        public async Task<IActionResult> PutAsync(
           [FromBody] CreateAlunoViewModels model,
           [FromRoute] int id)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }

            var aluno = await _alterarAlunoService.PutAsync(model, id);

            if (aluno == null) 
            {
                return NotFound();
            }

            return Ok(aluno);
        }
        
        [HttpDelete("api/v1/alunos/{id}")]
        //[Authorize(Policy = "Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var success = await _deleteAlunoService.DeleteAsync(id);

            if (!success) 
            {
                return BadRequest();
            }
            
            return Ok();          
        }
    }
}