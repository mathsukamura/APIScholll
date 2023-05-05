using System.Collections.Generic;

namespace Scholl.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Tela { get; set; }

        public ICollection<Perfil> Perfis { get; set; }
    }
}
