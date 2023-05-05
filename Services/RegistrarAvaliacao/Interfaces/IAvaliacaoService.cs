using Scholl.AvaliacaoModel;
using Scholl.ProfessorModel;
using Scholl.AvaliacaoViewModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Scholl.Services.RegistrarAvaliacao.Interfaces
{
    public interface ICriarAvalicaoService
    {
        Task<Avaliacao> PostAsync(CreateAvaliacaoViewModel model);
    };
    public interface IDeleteAvaliacaoService 
    {
        Task <bool> DeleteAsync( CreateAvaliacaoViewModel model, int id);
    }
    public interface IBuscarAvaliacaoService
    {
        Task <List<Avaliacao>> GetAsync();
        Task <Avaliacao> GetByIdAsync(int id);
    }
    public interface IAlterarAvalicaoService 
    {
        Task<Avaliacao> PutAsync(CreateAvaliacaoViewModel model, [FromRoute] int id);
    }
    
}
