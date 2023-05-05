using Scholl.AlunoModel;
using Scholl.Models.Enums;

namespace Scholl.Models
{
    public class AlunoPresenca
    {
        public int IdAluno { get; set; }
        public Aluno aluno { get; set; }
        public EPresencafalta presencafalta { get; set; }
    }
}
