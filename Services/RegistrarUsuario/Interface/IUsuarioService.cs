using Scholl.Models;
using Scholl.ProfessorViewModel;
using Scholl.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scholl.Services.RegistrarUsuario.Interface
{
    public interface IBuscarUsuarioService
    {
        public Task<IList<Usuario>> GetAsync();

        public Task<Usuario> GetByIdAsync(int id);
    }
    public interface ICriarUsuarioService 
    {
        public Task<Usuario> PostAsync(CreateUsuarioViewModel model);
    }
    public interface IAlterarUsuarioService
    {
        Task<Usuario> PutAsync(CreateUsuarioViewModel model, int id);
    }
    public interface IDeletarUsarioService
    {
        Task<bool> DeleteAsync(int id);
    }
}
