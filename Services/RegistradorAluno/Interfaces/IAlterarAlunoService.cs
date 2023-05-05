using Microsoft.AspNetCore.Mvc;
using Scholl.AlunoModel;
using Scholl.AlunoViewModel;
using System.Threading.Tasks;

namespace Scholl.Services.RegistradorAluno.Interfaces
{
    public interface IAlterarAlunoService
    {
        Task<Aluno> PutAsync(CreateAlunoViewModels model, [FromRoute] int id);
    }
}
