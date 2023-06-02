using Scholl.AlunoModel;
using Scholl.AvaliacaoModel;
using Scholl.Models.Enums;
using Scholl.ProfessorModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scholl.Services.FinalizarBimestre.Interface
{
    public interface IRepositorioAluno
    {
        List<Aluno> ObterTodosAlunos();
    }

    public interface IRepositorioAvaliacao
    {
        public Task<double> ObterTotalAvaliacao(EBimestre bimestre, int idProfessor);
    }

    public interface IRepositorioAvaliacaoNota
    {
        List<AvaliacaoNota> ObterNotasDoAluno(int alunoId, EBimestre bimestre, int idProfessor);
    }
    public interface IRepositorioHistorico 
    {
        void SalvarMediaBimestre(int alunoId, EBimestre bimestre, double media);
        double ObterMediaFinal(int alunoId);
    }
}
