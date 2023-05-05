using System.Collections.Generic;
using Scholl.AlunoModel;
using Scholl.CursoModel;
using Scholl.ProfessorModel;
using Scholl.AlunoTurmamodel;
using Scholl.ProfessorTurmamodel;

namespace Scholl.TurmaModel
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<AlunoTurma> AlunosTurmas { get; set; }
        public ICollection<ProfessorTurma> ProfessorTurmas { get; set; }
    }
}