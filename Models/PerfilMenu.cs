namespace Scholl.Models
{
    public class PerfilMenu
    {
        public int IdMenu { get; set; }
        public int IdPerfil  { get; set; }
        public Perfil Perfil { get; set; }
        public Menu Menu { get; set; }
    }
}
