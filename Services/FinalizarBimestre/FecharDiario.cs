using FluentValidation.Internal;
using Microsoft.EntityFrameworkCore;
using Scholl.AlunoModel;
using Scholl.AvaliacaoModel;
using Scholl.Data;
using Scholl.HistoricoModel;
using Scholl.Models.Enums;
using Scholl.ProfessorModel;
using Scholl.Services.FinalizarBimestre.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scholl.Services.FinalizarBimestre
{
    public class FecharDiario : IRepositorioAluno, IRepositorioAvaliacao, IRepositorioAvaliacaoNota, IRepositorioHistorico
    {
        private readonly AppDbcontext _dbContext;
        private readonly UserService _userService;

        public FecharDiario(AppDbcontext dbContext, UserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public List<Aluno> ObterTodosAlunos()
        {
            return _dbContext.Alunos.ToList();
        }

        public async Task<int> ObterTotalAvaliacao(EBimestre bimestre, int idProfessor)
        {
            return await _dbContext.Avaliacoes.CountAsync(avaliacao => avaliacao.Bimestre == bimestre && avaliacao.IdProfessor == idProfessor);
        }

        public List<AvaliacaoNota> ObterNotasDoAluno(int alunoId, EBimestre bimestre, int idProfessor)
        {
            return _dbContext.AvaliacaoNotas
                .Where(nota => nota.IdAluno == alunoId && nota.Avaliacao.Bimestre == bimestre && nota.Avaliacao.IdProfessor == idProfessor)
                .ToList();
        }

        public void SalvarMediaBimestre(int alunoId, EBimestre bimestre, double media)
        {
            var historico = _dbContext.Historicos.FirstOrDefault(h => h.IdAluno == alunoId);

            if (historico != null)
            {
                switch (bimestre)
                {
                    case EBimestre.Bimestre1:
                        historico.NotaFinal1 = (double)media;
                        break;
                    case EBimestre.Bimestre2:
                        historico.NotaFinal2 = (double)media;
                        break;
                    case EBimestre.Bimestre3:
                        historico.NotaFinal3 = (double)media;
                        break;
                    case EBimestre.Bimestre4:
                        historico.NotaFinal4 = (double)media;
                        break;
                }

                _dbContext.SaveChanges();
            }
        }

        public double ObterMediaFinal(int alunoId)
        {
            var historico = _dbContext.Historicos.FirstOrDefault(h => h.IdAluno == alunoId);

            if (historico == null)
            {
                return 0.0;
            }

            var notasFinais = new[] { historico.NotaFinal1, historico.NotaFinal2, historico.NotaFinal3, historico.NotaFinal4 };

            int quantidadeNotas = notasFinais.Count(n => n > 0);

            if (quantidadeNotas == 0)
            {
                return 0.0;
            }
            double somaNotas = notasFinais.Sum();

            double mediaFinal = somaNotas / quantidadeNotas;

            historico.MediaFinal = mediaFinal; 

            _dbContext.SaveChanges();

            return notasFinais.Average();
        }

        public async Task<Avaliacao> Obter

    }

}
