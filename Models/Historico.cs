using System;
using System.Collections.Generic;
using Scholl.AlunoModel;
using Scholl.Models.Enums;


namespace Scholl.HistoricoModel
{
    public class HistoricoEscolar
    {
        public EBimestre Bimestre {get; set;}
        public int Id {get; set;}
        public DateTime DataRegistro { get; set; }
    }

}