//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Scholl.Models;

//namespace Scholl.Data.Map.RelacionamentosNpN
//{
//    public class PerfilMenuEntityTypeconfiguration: IEntityTypeConfiguration<PerfilMenu>
//    {
//        public void Configure(EntityTypeBuilder<PerfilMenu> builder) 
//        {
//            builder.HasKey(x => new { x.IdPerfil, x.IdMenu });

//            builder.HasOne(x => x.Perfil)
//                .WithMany( p => p.MenuPerfil)
//                .HasForeignKey(x => x.IdPerfil);

//            builder.HasOne(x => x.Menu)
//                .WithMany(m => m.MenuPerfil)
//                .HasForeignKey(x => x.IdMenu);

//        }
//    }
//}
