using Scholl.ProfessorModel;
using Scholl.TurmaModel;

namespace Scholl.ProfessorTurmamodel
{
    public class ProfessorTurma
    {
        public int IdProfessor { get; set; }
        public int IdTurma { get; set; }
        public Turma Turma { get; set; }
        public Professor Professor { get; set; }
    }
}