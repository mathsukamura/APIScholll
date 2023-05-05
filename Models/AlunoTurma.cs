using Scholl.AlunoModel;
using Scholl.TurmaModel;

namespace Scholl.AlunoTurmamodel
{
    public class AlunoTurma
    {
        public int IdAluno { get; set; }
        public int IdTurma { get; set; }
        public Aluno Aluno { get; set; }
        public Turma Turma { get; set; }
    }
}