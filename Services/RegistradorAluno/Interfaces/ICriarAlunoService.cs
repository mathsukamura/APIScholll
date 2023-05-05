using System.Threading.Tasks;
using Scholl.AlunoViewModel;
using Scholl.AlunoModel;


namespace Scholl.Services.RegistradorAluno.Interfaces
{
    public interface ICriarAlunoService
    {
        Task<Aluno> PostAsync(CreateAlunoViewModels model);
    };

}