using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.AlunoModel;
using Scholl.HistoricoModel;

namespace Scholl.Data.Map
{
    public class HistoricoEntityTypeConfiguration : IEntityTypeConfiguration<Historico> 
    {
        public void Configure(EntityTypeBuilder<Historico> builder) 
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("tb_historico");

            builder.Property(s => s.NotaFinal1)
                .HasColumnName("notafinal1")
                .IsRequired()
                .HasColumnType("double precision");

            builder.Property(s => s.NotaFinal2)
                .HasColumnName("notafinal2")
                .IsRequired()
                .HasColumnType("double precision");

            builder.Property(s => s.NotaFinal3)
                .HasColumnName("notafinal3")
                .IsRequired()
                .HasColumnType("double precision");

            builder.Property(s => s.NotaFinal4)
                .HasColumnName("notafinal4")
                .IsRequired()
                .HasColumnType("double precision");

            builder.Property(s => s.MediaFinal)
                .HasColumnName("mediafinal")
                .IsRequired()
                .HasColumnType("double precision");

            builder.Property(s => s.DataRegistro)
                .HasColumnName("dataregistro")
                .IsRequired()
                .HasColumnType("timestamp");

            builder.HasOne(a => a.Aluno)
                .WithMany(a => a.Historico)
                .HasForeignKey(s => s.IdAluno);
        }
    }
}
