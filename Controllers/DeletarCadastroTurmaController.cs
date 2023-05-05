using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholl.Data;
using System;
using System.Threading.Tasks;

namespace Scholl.DeletarCadastroTurmaControlller;

public class DeletarCadastroTurmaControlller : ControllerBase
{
    [HttpDelete("Aluno/{id}")]
    public async Task<IActionResult> DeleteAsync(
    [FromServices] AppDbcontext context,
    [FromRoute] int id)
    {
        try
        {
            var Turma = await context
            .Turmas
            .FirstOrDefaultAsync(x => x.Id == id);

            if (Turma == null) return NotFound();

            context.Turmas.Remove(Turma);
            await context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}