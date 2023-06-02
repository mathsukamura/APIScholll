using Scholl.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scholl.ViewModels
{
    public class CreateMenuViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Tela { get; set; }
        [Required]
        public string Url { get; set; }
        public ICollection<Perfil> Perfis { get; set; }
    }
}
