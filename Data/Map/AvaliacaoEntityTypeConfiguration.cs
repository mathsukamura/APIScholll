using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.AvaliacaoModel;
using Scholl.ProfessorModel;

namespace Scholl.Data.Map
{
    class AvaliacaoEntityTypeConfiguration : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("tb_avaliacao");

            builder.Property(s => s.Descricao)
                 .HasColumnName("descricao")
                 .IsRequired()
                 .HasColumnType("varchar(24)");

            builder.Property(s => s.DataAplicacao)
                .HasColumnName("Data_Aplicacao")
                .IsRequired()
                .HasColumnType("timestamp");

            builder.HasOne(a => a.Professor)
                .WithMany(p => p.Avaliacoes)
                .HasForeignKey(a => a.IdProfessor);

            builder.Property(s => s.Bimestre)
                .HasColumnName("Bimestre")
                .IsRequired()
                .HasColumnType("int");
        }
    }
}