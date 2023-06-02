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

            builder.ToTable("tb_usuario");

            builder.Property(s => s.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasColumnType("Varchar(64)");

            builder.Property(s => s.Senha)
                .HasColumnName("senha")
                .IsRequired()
                .HasColumnType("Varchar(24)");

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired()   
                .HasColumnType("Varchar(24)");

            builder.Property(s => s.Sexo)
                .HasColumnName("Sexo")
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(a => a.Perfil)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(a => a.IdPerfil);

            builder.Property(a => a.DataCadastro)
                .HasColumnName("data_cadastro")
                .IsRequired()
                .HasColumnType("timestamp");

            builder.Property(s => s.DataNascimento)
                .HasColumnName("Data_Nascimento")
                .IsRequired()
                .HasColumnType("timestamp");

            builder.Property(a => a.Eprofessor)
                .HasColumnName("e_professor")
                .IsRequired()
                .HasColumnType("int");


        }
    }
}
