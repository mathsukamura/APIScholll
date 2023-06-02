using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholl.AlunoModel;
using Scholl.AvaliacaoModel;
using Scholl.Data;
using Scholl.Helpers;
using Scholl.Models.Enums;
using Scholl.Services;
using Scholl.Services.FinalizarBimestre.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Scholl.Controllers
{
    [AuthorizeUrl("finalizarbimestre")]
    [ApiController]
    [Route("api/notas")]
    public class NotasController : ControllerBase
    {
            private readonly IUserService _userService;
            private readonly AppDbcontext _context;
            private readonly IRepositorioAluno _repositorioAluno;
            private readonly IRepositorioAvaliacao _repositorioAvaliacao;
            private readonly IRepositorioAvaliacaoNota _repositorioAvaliacaoNota;
            private readonly IRepositorioHistorico _repositorioHistorico;

            public NotasController(
                IRepositorioAluno repositorioAluno,
                IRepositorioAvaliacao repositorioAvaliacao,
                IRepositorioAvaliacaoNota repositorioAvaliacaoNota,
                IRepositorioHistorico repositorioHistorico,
                IUserService userService,
                AppDbcontext context
                )
            {
                _repositorioAluno = repositorioAluno;
                _repositorioAvaliacao = repositorioAvaliacao;
                _repositorioAvaliacaoNota = repositorioAvaliacaoNota;
                _repositorioHistorico = repositorioHistorico;
                _userService = userService;
                _context= context;
            }

            [HttpPost("avalicao/FinalizarBimestre/{bimestre}")]
            public IActionResult CalcularMediaGeral(EBimestre bimestre)
            {

            var usuarioId = _userService.ObterUsuarioId();

            var professor = _context.Professores.FirstOrDefault(p => p.IdUsuario == usuarioId);

            if (professor == null)
            {
                return Unauthorized("você não tem autorização");
            }

            List<Aluno> alunos = _repositorioAluno.ObterTodosAlunos();
                double somaMedias = 0;
                int quantidadeAlunos = 0;

                foreach (var aluno in alunos)
                {
                List<Avaliacao> avaliacoes = _repositorioAvaliacao.ObterAvaliacoesDoAluno(aluno.Id, bimestre)
                    .Where(a => a.IdProfessor == professor.Id)
                    .ToList();

                List<AvaliacaoNota> notas = _repositorioAvaliacaoNota.ObterNotasDoAluno(aluno.Id, bimestre);

                    if (avaliacoes.Count == 0 || notas.Count == 0 || avaliacoes.Count != notas.Count)
                    {
                        continue; 
                    }

                    double somaNotas = 0;

                    for (int i = 0; i < avaliacoes.Count; i++)
                    {
                        double nota = notas[i].Nota;
                        somaNotas += nota;
                    }

                    double media = somaNotas / avaliacoes.Count;
                    somaMedias += media;
                    quantidadeAlunos++;

                     _repositorioHistorico.SalvarMediaBimestre(aluno.Id, bimestre, media);
                }

                if (quantidadeAlunos == 0)
                {
                    return BadRequest("Não foi possível calcular a média geral dos alunos.");
                }

                double mediaGeral = somaMedias / quantidadeAlunos;

                return Ok(mediaGeral);
            }

            [HttpPost("calcular-media-aluno/")]
            public IActionResult CalcularMediaAluno()
            {
                var usuarioId = _userService.ObterUsuarioId();

                var professor = _context.Professores.FirstOrDefault(p => p.IdUsuario == usuarioId);

                if (professor == null)
                {
                    return Unauthorized("Você não tem autorização.");
                }

                List<Aluno> alunos = _repositorioAluno.ObterTodosAlunos();

                Dictionary<int, double> mediasAlunos = new Dictionary<int, double>();

                foreach (var aluno in alunos)
                {
                    double mediaFinal = _repositorioHistorico.ObterMediaFinal(aluno.Id);

                    mediasAlunos.Add(aluno.Id, mediaFinal);
                }

                return Ok(mediasAlunos);
            }
    }

}
    


