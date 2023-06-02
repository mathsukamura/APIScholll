using Microsoft.AspNetCore.Authentication;
using Scholl.ViewModels;
using System.Collections.Generic;

namespace Scholl.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        public string TipoPerfil { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<PerfilMenu> MenuPerfil { get; set; }
        public void AtualizacaoPerfilViewModel(CreatePerfilViewModel viewModel)
        {
            if (viewModel == null)
            {
                return;
            }

            TipoPerfil= viewModel.TipoPerfil;
        }
    }
}
