using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.CursoModel;

namespace Scholl.Data.Map;

class CursoEntityTypeConfiguration : IEntityTypeConfiguration<Curso>
{

    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("tb_curso");

        builder.Property(s => s.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasColumnType("varchar(24)");

        builder.Property(s => s.DataCadastro)
                .HasColumnName("Data_Cadastro")
                .IsRequired()
                .HasColumnType("timestamp");

    }
}