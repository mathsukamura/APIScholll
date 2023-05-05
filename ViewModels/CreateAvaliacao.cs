using System.Security.AccessControl;
using System;
using System.ComponentModel.DataAnnotations;
using Scholl.Models.Enums;
using Scholl.AvaliacaoModel;

namespace Scholl.AvaliacaoViewModel;
public class CreateAvaliacaoViewModel
{
    [Required]
    public int Id { get; set; }
    public string Descricao { get; set; }
    [Required]
    public int IdProfessor { get; set; }
    public DateTime DataAplicacao { get; set; }
    public EBimestre Bimestre { get; set; }

    public Avaliacao ToEntity()
    {
        return new Avaliacao
        {
            Descricao = Descricao,
            IdProfessor = IdProfessor,
            Bimestre = Bimestre,
            DataAplicacao = DataAplicacao
        };
    }
}