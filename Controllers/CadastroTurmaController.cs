//using Microsoft.EntityFrameworkCore;
//using System;
//using Microsoft.AspNetCore.Mvc;
//using Scholl.Data;
//using Scholl.TurmaViewModel;
//using Scholl.TurmaModel;
//using System.Threading.Tasks;
//using System.Collections;
//using System.Collections.Generic;

//namespace Scholl.CriarLoginController
//{
//    public enum EStatus
//    {
//        aberto = 1,
//        fechado = 2
//    }
    
//    public class RegistrarCommand
//    {
//        public int Id { get; set; }
//        public EStatus Status { get; set; }
//        public bool PermiteVisualizar => Status == EStatus.fechado;
//        public IEnumerable<int> Diretores { get; set; }
//        public string Professores { get; set; }
//    }

//    /*
    
//    {
//        "id": 0,
//        "Status": 1,
//        "diretores": [1,2,3],
//        "professores": "1,2,3"
//    }

//    if (response.PermiteVisualizar)
//    {
        
//    }

//    */


//    class CriarTurmaController : ControllerBase
//    {
//        [HttpPost("Turma")]

//        public async Task<IActionResult> PostAsync(
//        [FromServices] AppDbcontext context,
//        [FromBody] CreateTurmaViewModels model)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest();

//            var Turma = new Turma
//            {

//                Nome = model.Nome,

//            };
//            try
//            {
//                await context.Turmas.AddAsync(Turma);
//                await context.SaveChangesAsync();
//                return Created($"v1/Turmas/{Turma.Id}", Turma);
//            }
//            catch (Exception)
//            {

//                return BadRequest();
//            }

//        }

//        public async Task<IActionResult> RegistrarAsync(
//            [FromServices] AppDbcontext context,
//            [FromBody] RegistrarCommand model)
//        {

//            return Created($"v1/Turmas/{model.Id}", model);
//        }
//    }
//}