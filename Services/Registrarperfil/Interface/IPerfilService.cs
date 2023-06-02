using Scholl.Models;
using Scholl.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scholl.Services.Registrarperfil.Interface
{
    public interface IBuscarPerfilService 
    {
        public Task<IList<Perfil>> GetAsync();
        public Task<Perfil> GetByIdAsync(int id);
    }

    public interface ICriarPerfilService
    {
        public Task<Perfil> PostAsync(CreatePerfilViewModel model); 
    }

    public interface IAlterarPerfilService 
    {
        public Task<Perfil> PutAsync(CreatePerfilViewModel model, int id);
    }

    public interface IDeletarPerfilService 
    {
        public Task<bool> DeleteAsync(int id);
    }
}
