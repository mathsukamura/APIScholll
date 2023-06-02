using Scholl.Models;
using Scholl.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scholl.Services.ControleMenu.Interface
{
    public interface IBuscarMenuService
    {
        public Task<IList<Menu>> GetAsync();

        public Task<Menu> GetByIdAsync(int id);
    }

    public interface ICriarMenuService
    {
        public Task<Menu> PostAsync(CreateMenuViewModel model);
    }

    public interface IAlterarMenuService 
    {
        public Task<Menu> PutAsync(CreateMenuViewModel model, int id);
    }

    public interface IDeletarMenuService
    {
        public Task<bool> DeleteAsync(int id);
    }
}
