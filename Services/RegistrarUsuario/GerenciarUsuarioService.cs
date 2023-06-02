using Microsoft.EntityFrameworkCore;
using Scholl.Data;
using Scholl.Models;
using Scholl.Models.Enums;
using Scholl.ProfessorModel;
using Scholl.ProfessorViewModel;
using Scholl.Services.RegistrarUsuario.Interface;
using Scholl.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scholl.Services.RegistrarUsuario
{
    public class GerenciarUsuarioService : 
        IBuscarUsuarioService, ICriarUsuarioService,
        IAlterarUsuarioService, IDeletarUsarioService
    {
        private readonly AppDbcontext _context;

        public GerenciarUsuarioService(AppDbcontext context) => _context = context;

        public async Task<IList<Usuario>> GetAsync() 
        {
            var usuario = await _context.Usuarios.AsNoTracking().ToListAsync();

            return usuario;
        }

        public async Task<Usuario> GetByIdAsync(int id) 
        {
            var usuario= await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id );

            return usuario;
        }

        public async Task<Usuario> PostAsync(CreateUsuarioViewModel model)
        {
            var usuario = model.CreateUser();

            if (usuario.Eprofessor == EProfessor.sim)
            {
                var professor = new Professor()
                {
                    Nome = usuario.Name,
                    Sexo = usuario.Sexo,
                    DataNascimento = usuario.DataNascimento,
                };

                usuario.Professor = professor;
            }

            await _context.Usuarios.AddAsync(usuario);

            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> PutAsync(CreateUsuarioViewModel model, int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
            {
                return null;
            }

            usuario.AtualizacaoUserViewModel(model);

            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> DeleteAsync(int id) 
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            _context.Usuarios.Remove(usuario);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
