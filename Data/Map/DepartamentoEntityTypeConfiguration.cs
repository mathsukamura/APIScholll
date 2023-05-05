using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.DepartamentoModel;

namespace Scholl.Data.Map;

class DepartamentoEntityTypeConfiguration : IEntityTypeConfiguration<Departamento>
{

    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("tb_departamento");

        builder.Property(s => s.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasColumnType("varchar(24)");
    }
}
