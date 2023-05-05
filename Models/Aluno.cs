using System;
using Scholl.TurmaModel;
using System.Collections.Generic;
using Scholl.AlunoTurmamodel;
using Scholl.Models.Enums;
using Scholl.AvaliacaoModel;
using Scholl.Models;

namespace Scholl.AlunoModel
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;
        public ESexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<AlunoTurma> AlunosTurmas { get; set; }
        public ICollection<AvaliacaoNota> NotasAvaliacao { get; set; }
        public ICollection<AlunoPresenca> Presencas { get; set; }

    }

}