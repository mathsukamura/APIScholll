using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scholl.Data;
using Scholl.ProfessorViewModel;

namespace Scholl.AlterarCad
{
    [ApiController]
    [Route("V1")]
    public class AlterarcadTurma : ControllerBase
    {

        public async Task<IActionResult> PutAsync(
        [FromServices] AppDbcontext context,
        [FromBody] CreateProfessorViewModels model,
        [FromRoute] int id)
        {
            if (!ModelState.IsValid)

                return BadRequest();

            var Turma = await context
            .Turmas
            .FirstOrDefaultAsync(x => x.Id == id);

            if (Turma == null)
                return NotFound();

            try
            {
                Turma.Nome = model.Nome;
                context.Turmas.Update(Turma);
                await context.SaveChangesAsync();
                return Ok(Turma);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}