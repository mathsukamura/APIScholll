using System.Collections.Generic;
using Scholl.ProfessorModel;
using System;
using Scholl.Models.Enums;
using Scholl.AvaliacaoViewModel;

namespace Scholl.AvaliacaoModel
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public DateTime DataAplicacao { get; set; }
        public string Descricao { get; set; }
        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }
        public EBimestre Bimestre { get; set; }
        public ICollection<AvaliacaoNota> Notas { get; set; }

        public void AtualizacaoViewModel(CreateAvaliacaoViewModel viewModel)
        {
            if (viewModel == null)
            {
                return;
            }

            DataAplicacao = viewModel.DataAplicacao;
            Descricao = viewModel.Descricao;
            Bimestre = viewModel.Bimestre;
        }
    }
}