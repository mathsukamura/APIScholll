using FluentValidation;
using Scholl.AlunoViewModel;

namespace Scholl.Services.Alunos
{
    public class AlunoValidator : AbstractValidator<CreateAlunoViewModels>
    {
        public AlunoValidator()
        {
            RuleFor(aluno => aluno.Nome)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(aluno => aluno.Sexo)
               .Cascade(CascadeMode.Stop)
               .NotNull()
               .NotEmpty();
        }
    }
}
