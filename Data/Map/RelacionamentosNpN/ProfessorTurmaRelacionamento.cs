using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.ProfessorTurmamodel;


namespace Scholl.Data.Map.relacionamento;

class ProfessorturmaEntityTypeConfiguration : IEntityTypeConfiguration<ProfessorTurma>
{
    public void Configure(EntityTypeBuilder<ProfessorTurma> builder)
    {
        builder.HasKey(x => new { x.IdProfessor, x.IdTurma });
    }
}