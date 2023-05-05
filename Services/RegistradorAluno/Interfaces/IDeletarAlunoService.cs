

using System.Threading.Tasks;

namespace Scholl.Services.RegistradorAluno.Interfaces
{
    public interface IDeletarAlunoService
    {
        Task<bool> DeleteAsync(int alunoId);
    }
}
