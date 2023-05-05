using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.AlunoTurmamodel;


namespace Scholl.Data.Map.relacionamento;

class AlunoTurmaEntityTypeConfiguration : IEntityTypeConfiguration<AlunoTurma>
{
    public void Configure(EntityTypeBuilder<AlunoTurma> builder)
    {
        builder.HasKey(x => new { x.IdAluno, x.IdTurma });
    }
}