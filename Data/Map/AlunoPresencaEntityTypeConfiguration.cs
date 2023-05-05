using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.AlunoModel;
using Scholl.Models;
using Scholl.Models.Enums;

namespace Scholl.Data.Map
{
    public class AlunoPresencaEntityTypeConfiguration : IEntityTypeConfiguration<AlunoPresenca>
    {
        public void Configure(EntityTypeBuilder<AlunoPresenca> builder)
        {
            builder.HasKey(ap => new { ap.IdAluno, ap.presencafalta });

            builder.ToTable("tb_aluno_presenca");

            builder.HasOne<Aluno>(ap => ap.aluno)
                .WithMany(a => a.Presencas)
                .HasForeignKey(ap => ap.IdAluno);

            builder.Property(ap => ap.presencafalta)
                .HasColumnName("presenca_falta")
                .IsRequired()
                .HasColumnType("int");
        }
    }
}