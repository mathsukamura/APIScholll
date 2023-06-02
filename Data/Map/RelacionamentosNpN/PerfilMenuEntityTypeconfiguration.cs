using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.Models;

namespace Scholl.Data.Map.RelacionamentosNpN
{
    public class PerfilMenuEntityTypeconfiguration : IEntityTypeConfiguration<PerfilMenu>
    {
        public void Configure(EntityTypeBuilder<PerfilMenu> builder)
        {
            builder.HasKey(x => new { x.IdPerfil, x.IdMenu });

            builder.ToTable("menu_perfil");

            builder.HasOne(x => x.Perfil)
                .WithMany(p => p.MenuPerfil)
                .HasForeignKey(x => x.IdPerfil);

            builder.HasOne(x => x.Menu)
                .WithMany(m => m.MenuPerfil)
                .HasForeignKey(x => x.IdMenu);

            builder.Property(x => x.Get)
                .HasColumnName("buscar")
                .IsRequired()
                .HasColumnType("boolean");

            builder.Property(x => x.Post)
                .HasColumnName("lancar")
                .IsRequired()
                .HasColumnType("boolean");

            builder.Property(x => x.Put)
                .HasColumnName("alterar")
                .IsRequired()
                .HasColumnType("boolean");

            builder.Property(x => x.Delete)
                .HasColumnName("Deletar")
                .IsRequired()
                .HasColumnType("boolean");

        }
    }
}
