using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Scholl.Helpers;
using Scholl.Models.Enums;
using Scholl.Services.LancarNota.Interface;
using Scholl.ViewModels;
using System.Threading.Tasks;

namespace Scholl.Controllers
{
    [AuthorizeUrl("lancarnota")]
    public class LancarNotaController : Controller
    {
        private readonly IBuscarNota _buscarNotas;
        private readonly IBuscarNota _buscarNota;
        private readonly ILancarNota _lancarNota;
        private readonly IAlterarNota _alterarNota;
        private readonly IDeletarNota _deletarNota;
        
        public LancarNotaController(ILancarNota lancarNota, IBuscarNota buscarNotas, IBuscarNota buscarNota, IAlterarNota alterarNota, IDeletarNota deletarNota)
        {
            _buscarNota= buscarNota;
            _buscarNotas= buscarNotas;
            _lancarNota= lancarNota;
            _alterarNota= alterarNota;
            _deletarNota= deletarNota;
        }

        [HttpGet("api/v1/avaliacao/notas/{bimentre}")]
        public async Task<IActionResult> GetAsync(EBimestre bimestre)
        {
            var notas = await _buscarNotas.GetAsync(bimestre);

            if (notas == null)
            {
                return NotFound();
            }


            return Ok(notas);
        }

        [HttpGet("api/v1/avaliacao/notas/{bimestre}/{id}")]
        public async Task<IActionResult> GetByIdAsync(EBimestre bimestre, int id) 
        {
            var nota = await _buscarNota.GetByIdAsync(bimestre,id);

            if (nota == null)
            {
                return NotFound();
            }

            return Ok(nota);
        }

        [HttpPost("api/v1/avaliacao/notas/")]
        public async Task<IActionResult> PostAsync(CreateAvaliacaoNota model, int id)
        {
            var nota = await _lancarNota.PostAsync(model, id);

            return Ok(nota);
        }

        [HttpPut("api/v1/avaliacao/notas/{bimestre}/{id}")]
        public async Task<IActionResult> PutAsync(CreateAvaliacaoNota model, EBimestre bimestre, int id)
        {
            var nota = await _alterarNota.PutAsync(model, bimestre, id);

            return Ok(nota);
        }

        [HttpDelete("api/v1/avaliacao/notas/{bimestre}/{id}")]
        public async Task<IActionResult> DeleteAsync(EBimestre bimestre, int id)
        {
            var result = await _deletarNota.DeleteAsync(bimestre, id);

            return Ok(result);
        }

    }
}
