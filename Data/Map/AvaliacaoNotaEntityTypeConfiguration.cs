using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.AvaliacaoModel;

namespace Scholl.Data.Map
{
    class AvaliacaoNotaEntityTypeConfiguration : IEntityTypeConfiguration<AvaliacaoNota>
    {
        public void Configure(EntityTypeBuilder <AvaliacaoNota> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("tb_avaliacao_nota");

            builder.HasOne(a => a.Avaliacao)
                .WithMany(at => at.Notas)
                .HasForeignKey(at => at.IdAvaliacao);

            builder.HasOne(a => a.Aluno)
                .WithMany(p => p.NotasAvaliacao)
                .HasForeignKey(a => a.IdAluno);

            builder.Property(s => s.Nota)
                .HasColumnName("nota")
                .IsRequired()
                .HasColumnType("double precision");

            builder.Property(s => s.DataRealizacao)
                .HasColumnName("data_registro")
                .IsRequired()
                .HasColumnType("timestamp");
        }
    }
}