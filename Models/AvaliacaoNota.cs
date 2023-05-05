using System.Collections.Generic;
using System;
using Scholl.AlunoModel;
using Scholl.AvaliacaoModel;
namespace Scholl.AvaliacaoModel
{
    public class AvaliacaoNota
    {
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public Aluno Aluno { get; set; }
        public int IdAvaliacao { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public float Nota { get; set; }
        public DateTime DataRealizacao { get; set; }
    }
}