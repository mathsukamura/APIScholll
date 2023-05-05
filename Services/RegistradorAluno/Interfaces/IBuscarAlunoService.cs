using Scholl.AlunoModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scholl.Services.RegistradorAluno.Interfaces
{
    public interface IBuscarAlunoService
    {
        Task<List<Aluno>> GetAsync();
        Task<Aluno> GetByIdAsync(int id);
    }
}
