using Scholl.AvaliacaoModel;
using Scholl.Models.Enums;
using Scholl.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scholl.Services.LancarNota.Interface
{
    public interface ILancarNota
    {
        Task<AvaliacaoNota> PostAsync(CreateAvaliacaoNota model, int id);
    }
    public interface IBuscarNota 
    {
        Task<IList<AvaliacaoNota>> GetAsync(EBimestre bimestre);
        Task<AvaliacaoNota> GetByIdAsync(EBimestre bimestre, int id);
    }
    public interface IAlterarNota 
    {
        Task<AvaliacaoNota> PutAsync(CreateAvaliacaoNota model, EBimestre bimestre, int id);
    }
    public interface IDeletarNota
    {
        Task<bool> DeleteAsync(EBimestre bimestre, int id);
    }
}
