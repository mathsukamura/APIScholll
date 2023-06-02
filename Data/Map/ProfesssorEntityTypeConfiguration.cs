using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.ProfessorModel;
using Scholl.ProfessorTurmamodel;

namespace Scholl.Data.Map;

class ProfessorEntityTypeConfiguration : IEntityTypeConfiguration<Professor>
{

    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("tb_Professor");

        builder.Property(s => s.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasColumnType("varchar(150)");

        builder.Property(s => s.DataRegistro)
                .HasColumnName("Data_Registro")
                .IsRequired()
                .HasColumnType("timestamp");

        builder.Property(s => s.Sexo)
                .HasColumnName("Sexo")
                .IsRequired()
                .HasColumnType("int");

        builder.Property(s => s.DataNascimento)
                .HasColumnName("Data_Nascimento")
                .IsRequired()
                .HasColumnType("timestamp");

        builder.HasOne(p => p.Usuario)
               .WithOne(u => u.Professor)
               .HasForeignKey<Professor>(p => p.IdUsuario);

        builder.HasMany<ProfessorTurma>(a => a.professorTurma)
                .WithOne(at => at.Professor)
                .HasForeignKey(at => at.IdProfessor);
    }
}
