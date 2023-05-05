using Scholl.AvaliacaoModel;
using Scholl.ViewModels;
using System.Threading.Tasks;

namespace Scholl.Services.RegistrarNotaAvaliacao.Interface
{
    public interface ICriarNotaAvaliacao
    {
        Task<AvaliacaoNota> PostAsync(CreateAvaliacaoNota model);
    }
    public interface IbuscarNotaAvaliacao 
    {
        Task<AvaliacaoNota> GetAsync();
        Task<AvaliacaoNota> GetByIdAsync(int id);
    }
    public interface IAlterarNotaAvaliacao
    {
        Task<AvaliacaoNota> PutAsync( CreateAvaliacaoNota model, int id);
    }
    public interface IDeleteNotaAvaliacao 
    {
        Task<bool> DeleteAsync(int id);
    }
}
