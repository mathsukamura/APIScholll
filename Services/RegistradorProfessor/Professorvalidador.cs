using FluentValidation;
using Scholl.ProfessorViewModel;

namespace Scholl.Services.RegistradorProfessor
{
    public class ProfessorValidador : AbstractValidator<CreateProfessorViewModels>
    {
        public ProfessorValidador()
        {
            RuleFor(professor => professor.Nome)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(professor => professor.Sexo)
               .Cascade(CascadeMode.Stop)
               .NotNull()
               .NotEmpty();
        }
    }
}
