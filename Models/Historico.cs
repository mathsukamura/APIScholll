using System;
using System.Collections.Generic;
using Scholl.AlunoModel;
using Scholl.Models.Enums;


namespace Scholl.HistoricoModel
{
    public class Historico
    {
        public EBimestre Bimestre {get; set;}
        public int Id {get; set;}
        public int IdAluno { get; set;}
        public double NotaFinal1 { get; set;}
        public double NotaFinal2 { get; set;}
        public double NotaFinal3 { get; set; }
        public double NotaFinal4 { get; set; }
        public double MediaFinal { get; set; }
        public Aluno Aluno { get; set;}
        public DateTime DataRegistro { get; set; }
    }

}