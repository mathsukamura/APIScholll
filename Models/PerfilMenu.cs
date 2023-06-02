namespace Scholl.Models
{
    public class PerfilMenu
    {
        public int IdMenu { get; set; }
        public int IdPerfil { get; set; }
        public Perfil Perfil { get; set; }
        public Menu Menu { get; set; }
        public bool Get { get; set; }
        public bool Post { get;set; }
        public bool Put { get; set; }
        public bool Delete { get;set; }
    }
}
