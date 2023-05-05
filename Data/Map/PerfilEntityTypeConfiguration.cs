using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.Models;

namespace Scholl.Data.Map
{
    public class PerfilEntityTypeConfiguration: IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder <Perfil> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("tb_perfil");

            builder.Property(s => s.TipoPerfil)
                .HasColumnName("tipoperfil")
                .IsRequired()
                .HasColumnType("varchar(15)");
        }
    }
}