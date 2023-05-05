using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.Models;

namespace Scholl.Data.Map
{
    public class UsuarioEntirtyTypeConfiguration: IEntityTypeConfiguration<Usuario>
    {
       public void Configure(EntityTypeBuilder<Usuario> builder) 
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("usuario");

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasColumnType("Varchar(24)");

            builder.HasOne(a => a.Perfil)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(a => a.IdPerfil);

            builder.Property(a => a.DataCadastro)
                .HasColumnName("data_cadastro")
                .IsRequired()
                .HasColumnType("DateTime");
        }
    }
}
