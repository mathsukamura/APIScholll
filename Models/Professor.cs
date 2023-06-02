using System;
using Scholl.TurmaModel;
using System.Collections.Generic;
using Scholl.ProfessorTurmamodel;
using Scholl.Models.Enums;
using Scholl.AvaliacaoModel;
using Scholl.Models;

namespace Scholl.ProfessorModel
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;
        public ESexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<ProfessorTurma> professorTurma { get; set; }
        public ICollection<Avaliacao> Avaliacoes { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

    }

}