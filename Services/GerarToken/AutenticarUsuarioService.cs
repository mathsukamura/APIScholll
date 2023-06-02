using Microsoft.EntityFrameworkCore;
using Scholl.Data;
using Scholl.LoginModel;
using Scholl.Models;
using Scholl.Services.GerarToken.Interface;
using System.Threading.Tasks;

namespace Scholl.Services.GerarToken
{
    public class AutenticarUsuarioService : IAutenticarUsuario
    {
        private readonly AppDbcontext _context;

        public AutenticarUsuarioService(AppDbcontext context) => _context = context;

        public async Task<Usuario> AutenticacaoAsync( Login logins) 
        {
            var usuario = await _context.Usuarios
                .Include(x=> x.Perfil)
                .FirstOrDefaultAsync(x => x.Email == logins.Email 
                && x.Senha == logins.Senha);

            if( usuario == null)
            {
                return null;
            }

            return usuario;

        }

    }
}
