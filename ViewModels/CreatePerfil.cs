using Scholl.Models;
using System.ComponentModel.DataAnnotations;

namespace Scholl.ViewModels
{
    public class CreatePerfilViewModel
    {
        public int Id { get; set; }
        [Required]
        public string TipoPerfil { get; set; }

        public Perfil CreatePerfil() 
        {
            return new Perfil
            {
                TipoPerfil = TipoPerfil,
            };
        }
    }
}
