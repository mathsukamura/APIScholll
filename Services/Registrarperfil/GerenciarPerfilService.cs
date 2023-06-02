using Microsoft.EntityFrameworkCore;
using Scholl.Data;
using Scholl.Models;
using Scholl.Services.Registrarperfil.Interface;
using Scholl.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scholl.Services.Registrarperfil
{
    public class GerenciarPerfilService: 
        IBuscarPerfilService, ICriarPerfilService,
        IAlterarPerfilService,IDeletarPerfilService
    {
        private readonly AppDbcontext _context;

        public GerenciarPerfilService(AppDbcontext context) => _context = context;

        public async Task<IList<Perfil>> GetAsync() 
        {
            var perfil = await _context.Perfils.AsNoTracking().ToListAsync();

            return perfil;
        }

        public async Task<Perfil> GetByIdAsync(int id) 
        {
            var perfil = await _context.Perfils.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return perfil;
        }

        public async Task<Perfil> PostAsync(CreatePerfilViewModel model) 
        {
            var perfil = model.CreatePerfil();

            await _context.Perfils.AddAsync(perfil);

            await _context.SaveChangesAsync();

            return perfil;
        }

        public async Task <Perfil> PutAsync(CreatePerfilViewModel model, int id) 
        {
            var perfil = await _context.Perfils.FirstOrDefaultAsync(x => x.Id == id);

            perfil.AtualizacaoPerfilViewModel(model);

            await _context.SaveChangesAsync();

            return perfil;

        }
        public async Task<bool> DeleteAsync(int id) 
        {
            var perfil = await _context.Perfils.FirstOrDefaultAsync(x => x.Id == id);
            
            _context.Perfils.Remove(perfil);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
