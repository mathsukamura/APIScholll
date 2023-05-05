using System;
namespace Scholl.CursoModel
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}