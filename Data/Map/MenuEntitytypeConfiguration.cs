using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholl.Models;
using System.Collections.Generic;

namespace Scholl.Data.Map
{
    public class MenuEntitytypeConfiguration: IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder) 
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("tb_menu");

            builder.Property(s => s.Tela)
                .HasColumnName("tela")
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(s => s.Url)
                .HasColumnName("url")
                .IsRequired()
                .HasColumnType("varchar(24)");

            //builder.HasMany(x => x.Perfis)
            //    .WithMany(x => x.Menus)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "menu_vs_perfil",
            //        j => j
            //            .HasOne<Perfil>()
            //            .WithMany()
            //            .HasForeignKey("IdPerfil"),

            //        j => j
            //            .HasOne<Menu>()
            //            .WithMany()
            //            .HasForeignKey("IdMenu"));
        }
    }
}
