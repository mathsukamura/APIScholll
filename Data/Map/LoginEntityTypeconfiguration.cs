using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.LoginModel;

namespace Scholl.Data.Map;

class LoginEntityTypeConfiguration : IEntityTypeConfiguration<Login>
{

    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("tb_login");

        builder.Property(s => s.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasColumnType("varchar(150)");

        builder.Property(s => s.Username)
                .HasColumnName("username")
                .IsRequired()
                .HasColumnType("varchar(24)");

        builder.Property(s => s.Password)
                .HasColumnName("Senha")
                .IsRequired()
                .HasColumnType("varchar(24)");

        builder.Property(s => s.Phone)
            .HasColumnName("n_celular")
            .IsRequired()
            .HasColumnType("varchar(15)");

        builder.Property(s => s.DataRegistro)
                .HasColumnName("Data_Registro")
                .IsRequired()
                .HasColumnType("timestamp");

    }
}