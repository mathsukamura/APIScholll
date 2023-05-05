using System;
using System.Data.Common;

namespace Scholl.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdPerfil { get; set; }
        public Perfil Perfil { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
