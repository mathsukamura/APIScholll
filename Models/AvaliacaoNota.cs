using System.Collections.Generic;
using System;
using Scholl.AlunoModel;
using Scholl.AvaliacaoModel;
using Scholl.ViewModels;
using Scholl.Services.LancarNota;

namespace Scholl.AvaliacaoModel
{
    public class AvaliacaoNota
    {
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public Aluno Aluno { get; set; }
        public int IdAvaliacao { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public double Nota { get; set; }
        public DateTime DataRealizacao { get; set; }

        public void AtualizaNota(CreateAvaliacaoNota viewmodel) 
        {
            if (viewmodel == null) 
            {
                return;
            }
            Nota= viewmodel.Nota;
            DataRealizacao= viewmodel.DataRealizacao;
        }
    }
}