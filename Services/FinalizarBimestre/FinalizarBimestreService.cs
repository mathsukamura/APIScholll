using Microsoft.AspNetCore.Mvc;
using Scholl.AvaliacaoModel;
using Scholl.Services.FinalizarBimestre.Interface;
using System.Collections.Generic;

namespace Scholl.Services.FinalizarBimestre
{
    public class FinalizarBimestreService
    {
        

        //public IActionResult CalcularMedia(int alunoId)
        //{
        //    List<Avaliacao> avaliacoes = _repositorioAvaliacao.ObterAvaliacoesDoAluno(alunoId);
        //    List<AvaliacaoNota> notas = _repositorioAvaliacaoNota.ObterNotasDoAluno(alunoId);

        //    if (avaliacoes.Count == 0 || notas.Count == 0 || avaliacoes.Count != notas.Count)
        //    {
        //        return null;
        //    }

        //    double somaNotas = 0;

        //    for (int i = 0; i < avaliacoes.Count; i++)
        //    {

        //        double nota = notas[i].Nota;

        //        somaNotas += nota;
        //    }

        //    double media = somaNotas / avaliacoes.Count;

        //    return media;
        //}
    }
}
