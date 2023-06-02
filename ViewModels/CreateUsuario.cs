using Scholl.Models;
using Scholl.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Scholl.ViewModels
{
    public class CreateUsuarioViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int IdPerfil { get; set; }
        [Required]
        public ESexo Sexo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public EProfessor EProfessor { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public Perfil Perfil { get; set; }

        public Usuario CreateUser() 
        {
            return new Usuario
            {
                Name = Name,
                IdPerfil = IdPerfil,
                Email = Email,
                Senha = Senha,
                Eprofessor = EProfessor,
                Sexo = Sexo,
                DataNascimento = DataNascimento
            };
        }
    }
}
