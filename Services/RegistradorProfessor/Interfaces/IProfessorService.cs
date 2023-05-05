using Scholl.ProfessorViewModel;
using Scholl.ProfessorModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Scholl.Services.registradorProfessor.Interfaces
{
    public interface ICriarProfessorService
    {
        Task<Professor> PostAsync(CreateProfessorViewModels model);
    };

    public interface IDeletarProfessorService
    {
        Task<bool> DeleteAsync(int id);
    };

    public interface IAlterarProfessorService
    {
        Task<Professor> PutAsync(CreateProfessorViewModels Model, [FromRoute] int id);
    };

    public interface IBuscarProfessorService 
    {
        Task <List<Professor>> GetAsync();
        Task<Professor> GetByIdAsync(int id);
    };
}
