using Scholl.AlunoModel;
using Scholl.AvaliacaoModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Scholl.ViewModels
{
    public class CreateAvaliacaoNota
    {
        [Required]
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public Aluno Aluno { get; set; }
        [Required]
        public int IdAvaliacao { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public float Nota { get; set; }
        public DateTime DataRealizacao { get; set; } = DateTime.Now;

        public AvaliacaoNota ToEntity()
        {
            return new AvaliacaoNota 
            {
                IdAluno = IdAluno,
                Aluno = Aluno,
                Avaliacao = Avaliacao,
                IdAvaliacao= IdAvaliacao,
                Nota= Nota,
                DataRealizacao= DataRealizacao,


            };   
        }
    }
}
