using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.AlunoModel;
using Scholl.AlunoTurmamodel;
using Scholl.TurmaModel;

namespace Scholl.Data.Map;

class AlunoEntityTypeConfiguration : IEntityTypeConfiguration<Aluno>
{

    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("tb_Aluno");

        builder.Property(s => s.Nome)
            .HasColumnName("nome")
            .IsRequired()
            .HasColumnType("varchar(150)");

        builder.Property(s => s.DataRegistro)
            .HasColumnName("data_registro")
            .IsRequired()
            .HasColumnType("timestamp");

        builder.Property(s => s.Sexo)
            .HasColumnName("sexo")
            .IsRequired()
            .HasColumnType("int");

        builder.Property(s => s.DataNascimento)
            .HasColumnName("data_nascimento")
            .IsRequired()
            .HasColumnType("timestamp");

        // Configura o relacionamento muitos para muitos com a classe Turma
        builder.HasMany<AlunoTurma>(a => a.AlunosTurmas)
            .WithOne(at => at.Aluno)
            .HasForeignKey(at => at.IdAluno);

        // configura relacionamento um para muitos
        //  builder.Entity<Aluno>()
        //     .HasOne<Nota>(s => s.Nota)
        //     .WithMany(g => g.Aluno)
        //     .HasForeignKey(s => s.CurrentGradeId);
    }

}