using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scholl.Data;


namespace Scholl.BuscarTurmaControlller
{
    [ApiController]
    [Route("V1")]
    public class BuscarTurmaControlller : ControllerBase
    {
        [HttpGet]
        [Route("Turma")]
        public async Task<IActionResult> GetAsync(
        [FromServices] AppDbcontext context)
        {
            var Turma = await context
            .Turmas
            .AsNoTracking()
            .ToListAsync();
            return Ok(Turma);
        }
        [HttpGet]
        [Route("Turma/{id}")]
        public async Task<IActionResult> GetByIdAsync(
        [FromServices] AppDbcontext context, 
        [FromRoute] int id)
        {
            var Turma = await context
            .Turmas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return Turma == null
            ? NotFound()
            : Ok(Turma);
        }
    }

}