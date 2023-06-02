using Scholl.LoginModel;
using Scholl.Models;
using System.Threading.Tasks;

namespace Scholl.Services.GerarToken.Interface
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuarios);

    }
    public interface IAutenticarUsuario 
    {
        Task<Usuario> AutenticacaoAsync( Login logins);
    }
}
