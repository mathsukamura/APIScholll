using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.TurmaModel;
using Scholl.AlunoTurmamodel;
using Scholl.ProfessorTurmamodel;

namespace Scholl.Data.Map;

class TurmaEntityTypeConfiguration : IEntityTypeConfiguration<Turma>
{

    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("tb_Turma");

        builder.Property(s => s.Nome)
            .HasColumnName("nome")
            .IsRequired()
            .HasColumnType("varchar(24)");

        // Configura o relacionamento muitos para muitos com a classe Aluno
        builder.HasMany<AlunoTurma>(t => t.AlunosTurmas)
            .WithOne(at => at.Turma)
            .HasForeignKey(at => at.IdTurma);

        builder.HasMany<ProfessorTurma>(t => t.ProfessorTurmas )
            .WithOne(at => at.Turma)
            .HasForeignKey(at => at.IdTurma);
    }
}